using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TranTuanAnh_Buoi4.Areas.Admin.Models;
using TranTuanAnh_Buoi4.Models;
using TranTuanAnh_Buoi4.Repositories;

namespace TranTuanAnh_Buoi4.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly IProductRepository productRepository;

        public SanPhamController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productRepository.GetAllAsync();
            return View(products);
        }
        
        public async Task<IActionResult> Display(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
