using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TranTuanAnh_Buoi4.Areas.Admin.Models;
using TranTuanAnh_Buoi4.Models;
using TranTuanAnh_Buoi4.Repositories;

namespace TranTuanAnh_Buoi4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductImages productImages;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IProductImages productImages)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.productImages = productImages;
        }

        [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Customer},{SD.Role_Employee}")]
        public async Task<IActionResult> Index()
        {
            var products = await productRepository.GetAllAsync();
            return View(products);
        }


        [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Customer},{SD.Role_Employee}")]
        public async Task<IActionResult> Display(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Employee}")]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }


        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Employee}")]
        public async Task<IActionResult> Add(Product product, IFormFile imageUrl, List<IFormFile> imageUrls)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null && imageUrl.Length > 0)
                {
                    product.ImageUrl = await SaveImage(imageUrl);
                }

                await productRepository.AddAsync(product);

                if (imageUrls != null && imageUrls.Count > 0)
                {
                    foreach (var file in imageUrls)
                    {
                        await productImages.AddAsync(new ProductImage
                        {
                            Url = await SaveImage(file),
                            ProductId = product.Id
                        });
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            var categories = await categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }


        [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Employee}")]
        public async Task<IActionResult> Update(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            var categories = await categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }


        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Employee}")]
        public async Task<IActionResult> Update(int id, Product product, IFormFile imageUrl)
        {
            ModelState.Remove("ImageUrl");

            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingProduct = await productRepository.GetByIdAsync(id);

                if (imageUrl == null)
                {
                    product.ImageUrl = existingProduct.ImageUrl;
                }
                else
                {
                    product.ImageUrl = await SaveImage(imageUrl);
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.ImageUrl = product.ImageUrl;

                await productRepository.UpdateAsync(existingProduct);

                return RedirectToAction(nameof(Index));
            }

            var categories = await categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }


        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost, ActionName("DeleteConfirmed")]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName;
        }
    }
}
