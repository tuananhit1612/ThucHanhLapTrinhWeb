using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TranTuanAnh_Buoi2.Models;
using TranTuanAnh_Buoi2.Repositories;

namespace TranTuanAnh_Buoi2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(int? d)
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = categories;

            var products = _productRepository.GetAll();
            if (d.HasValue && d.Value > 0)
            {
                products = products.Where(p => p.CategoryId == d.Value);
            }
            return View(products);
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
