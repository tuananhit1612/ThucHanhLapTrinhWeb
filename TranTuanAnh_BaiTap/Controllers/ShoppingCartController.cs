using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TranTuanAnh_BaiTap.Extensions;
using TranTuanAnh_BaiTap.Models;
using TranTuanAnh_BaiTap.Repositories;

namespace TranTuanAnh_BaiTap.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IXeRepository _XeRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShoppingCartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IXeRepository XeRepository)
        {
            _XeRepository = XeRepository;
            _applicationDbContext = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult IncreaseQuantity(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

            var item = cart.Items.FirstOrDefault(i => i.XeID == id);
            if (item != null)
            {
                item.Quantity++;
            }
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DecreaseQuantity(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

            var item = cart.Items.FirstOrDefault(i => i.XeID == id);
            if (item != null && item.Quantity > 1)
            {
                item.Quantity--;
            }
            else if (item != null && item.Quantity == 1)
            {
                cart.Items.Remove(item);
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddToCart(int id, int quantity)
        {
            // Giả sử bạn có phương thức lấy thông tin sản phẩm từ productId
            var product = await GetProductFromDatabase(id);
            var cartItem = new CartItem
            {
                XeID = id,
                TenXe = product.TenXe,
                Gia = product.Gia,
                Quantity = quantity
            };
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ??
            new ShoppingCart();
            cart.AddItem(cartItem);
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            return View(cart);

        }
        [Authorize]
        public IActionResult Checkout()
        {
            return View(new TuanAnh_DonHang());
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(TuanAnh_DonHang order)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.GetUserAsync(User);
            order.UserId = user.Id;
            order.OrderDate = DateTime.UtcNow;
            order.TotalPrice = cart.Items.Sum(i => i.Gia * i.Quantity);
            order.OrderDetails = cart.Items.Select(i => new TuanAnh_ChiTietDonHang
            {
                XeId = i.XeID,
                Quantity = i.Quantity,
                Price = i.Gia
            }).ToList();
            _applicationDbContext.TuanAnh_DonHang.Add(order);
            await _applicationDbContext.SaveChangesAsync();
            HttpContext.Session.Remove("Cart");
            return View("OrderCompleted", order.Id); // Trang xác nhận hoàn thành đơn hàng
        }
        private async Task<TuanAnh_Xe> GetProductFromDatabase(int id)
        {
            // Truy vấn cơ sở dữ liệu để lấy thông tin sản phẩm
            var product = await _XeRepository.GetByIdAsync(id);
            return product;
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
            if (cart is not null)
            {
                cart.RemoveItem(id);
                // Lưu lại giỏ hàng vào Session sau khi đã xóa mục
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
    }
}
