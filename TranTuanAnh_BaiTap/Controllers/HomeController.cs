using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TranTuanAnh_BaiTap.Models;
using TranTuanAnh_BaiTap.Repositories;

namespace TranTuanAnh_BaiTap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IXeRepository _xeRepo;
        public HomeController(ILogger<HomeController> logger, IXeRepository xeRepo)
        {
            _logger = logger;
            _xeRepo = xeRepo;
        }

        public async Task<IActionResult> Index()
        {
            var dsXe = await _xeRepo.GetAllAsync();
            return View(dsXe);
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
