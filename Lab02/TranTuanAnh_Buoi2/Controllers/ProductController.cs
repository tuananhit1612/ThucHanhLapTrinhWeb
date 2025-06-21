using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TranTuanAnh_Buoi2.Models;
using TranTuanAnh_Buoi2.Repositories;

namespace TranTuanAnh_Buoi2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository,
ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Add()
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile imageUrl, List<IFormFile> imageUrls)
        {
            const long maxFileSize = 2 * 1024 * 1024;
            var allowedTypes = new[] { "image/jpeg", "image/png", "image/gif" };

            // Kiểm tra file chính
            if (imageUrl != null)
            {
                if (!allowedTypes.Contains(imageUrl.ContentType))
                {
                    ModelState.AddModelError("ImageUrl", "Chỉ cho phép tệp hình ảnh (jpg, png, gif).");
                }
                else if (imageUrl.Length > maxFileSize)
                {
                    ModelState.AddModelError("ImageUrl", "Kích thước tệp tối đa là 2MB.");
                }
                else
                {
                    product.ImageUrl = await SaveImage(imageUrl);
                    ModelState.Remove(nameof(product.ImageUrl));
                }
            }

            // Kiểm tra các file phụ
            if (imageUrls != null)
            {
                product.ImageUrls = new List<string>();
                foreach (var file in imageUrls)
                {
                    if (!allowedTypes.Contains(file.ContentType))
                    {
                        ModelState.AddModelError("ImageUrls", "Chỉ cho phép tệp hình ảnh (jpg, png, gif).");
                        continue;
                    }
                    if (file.Length > maxFileSize)
                    {
                        ModelState.AddModelError("ImageUrls", "Kích thước tệp tối đa là 2MB.");
                        continue;
                    }
                    product.ImageUrls.Add(await SaveImage(file));
                }
            }

            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private async Task<string> SaveImage(IFormFile image)
        {
            // Thay đổi đường dẫn theo cấu hình của bạn
            var savePath = Path.Combine("wwwroot/images", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName; // Trả về đường dẫn tương đối
        }
        // Các actions khác như Display, Update, Delete
        // Display a list of products

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }
        // Display a single product
        public IActionResult Display(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Show the product update form
        public IActionResult Update(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // Process the product update
        [HttpPost]
        public async Task<IActionResult> Update(Product product, IFormFile imageUrl, List<IFormFile> imageUrls)
        {
            const long maxFileSize = 2 * 1024 * 1024;
            var allowedTypes = new[] { "image/jpeg", "image/png", "image/gif" };
            ModelState.Remove(nameof(product.ImageUrls));
            var oldProduct = _productRepository.GetById(product.Id);
            if (oldProduct == null)
            {
                return NotFound();
            }

            if (imageUrl != null)
            {
                if (!allowedTypes.Contains(imageUrl.ContentType))
                {
                    ModelState.AddModelError("ImageUrl", "Chỉ cho phép tệp hình ảnh (jpg, png, gif).");
                }
                else if (imageUrl.Length > maxFileSize)
                {
                    ModelState.AddModelError("ImageUrl", "Kích thước tệp tối đa là 2MB.");
                }
                else
                {
                    product.ImageUrl = await SaveImage(imageUrl);
                    ModelState.Remove(nameof(product.ImageUrl));
                }
            }
            else
            {
                product.ImageUrl = oldProduct.ImageUrl;
            }

            if (imageUrls != null)
            {
                product.ImageUrls = new List<string>();
                foreach (var file in imageUrls)
                {
                    if (!allowedTypes.Contains(file.ContentType))
                    {
                        ModelState.AddModelError("ImageUrls", "Chỉ cho phép tệp hình ảnh (jpg, png, gif).");
                        continue;
                    }
                    if (file.Length > maxFileSize)
                    {
                        ModelState.AddModelError("ImageUrls", "Kích thước tệp tối đa là 2MB.");
                        continue;
                    }
                    product.ImageUrls.Add(await SaveImage(file));
                }
            }
            else
            {
                product.ImageUrls = oldProduct.ImageUrls;
            }

            _productRepository.Update(product);
            return RedirectToAction("Index");

        }
        // Show the product delete confirmation
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // Process the product deletion
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
