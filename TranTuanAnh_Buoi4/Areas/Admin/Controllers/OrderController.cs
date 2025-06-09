using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranTuanAnh_Buoi4.Areas.Admin.Models;
using TranTuanAnh_Buoi4.Models;
using TranTuanAnh_Buoi4.Repositories;

namespace TranTuanAnh_Buoi4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Employee}")]
        public async Task<IActionResult> Index()
        {
            var orders = await _applicationDbContext.Orders
                .Include(o => o.ApplicationUser)
                .ToListAsync();
            return View(orders);
        }
        [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Employee}")]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _applicationDbContext.Orders
                .Include(o => o.ApplicationUser)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Employee}")]
        public async Task<IActionResult> Edit(int id, Order updatedOrder)
        {
            if (id != updatedOrder.Id)
            {
                return NotFound();
            }

            try
            {
                var existingOrder = await _applicationDbContext.Orders
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (existingOrder == null)
                {
                    return NotFound();
                }

                // Luôn cập nhật, không cần kiểm tra ModelState
                existingOrder.ShippingAddress = updatedOrder.ShippingAddress;
                existingOrder.Notes = updatedOrder.Notes;

                await _applicationDbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "Cập nhật đơn hàng thành công!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderExists(updatedOrder.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> OrderExists(int id)
        {
            return await _applicationDbContext.Orders.AnyAsync(o => o.Id == id);
        }

        [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Employee}")]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _applicationDbContext.Orders
                .Include(o => o.ApplicationUser)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
