using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using TranTuanAnh_BaiTap.Models;
using TranTuanAnh_BaiTap.Repositories;
using Microsoft.AspNetCore.Authorization;
using TranTuanAnh_BaiTap.Areas.Admin.Models;

namespace TranTuanAnh_BaiTap.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TuanAnh_HangXeController : Controller
    {
        private readonly IHangXeRepository _hangXeRepo;

        public TuanAnh_HangXeController(IHangXeRepository hangXeRepo)
        {
            _hangXeRepo = hangXeRepo;
        }
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Index(string search)
        {
            var hangXes = await _hangXeRepo.GetAllAsync();

            if (!string.IsNullOrEmpty(search))
                hangXes = hangXes.Where(h => h.TenHang.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            return View(hangXes);
        }
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Details(int id)
        {
            var hangXe = await _hangXeRepo.GetByIdAsync(id);
            if (hangXe == null)
                return NotFound();

            return View(hangXe);
        }
        [Authorize(Roles = $"{SD.Role_Admin}")]

        // Hiển thị form thêm mới
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Create(TuanAnh_HangXe hangXe)
        {
                await _hangXeRepo.AddAsync(hangXe);
                return RedirectToAction(nameof(Index));
        }

        // Hiển thị form sửa
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Edit(int id)
        {
            var hangXe = await _hangXeRepo.GetByIdAsync(id);
            if (hangXe == null)
                return NotFound();

            return View(hangXe);
        }

        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Edit(TuanAnh_HangXe hangXe)
        {
                await _hangXeRepo.UpdateAsync(hangXe);
               return RedirectToAction(nameof(Index));

        }

        // Hiển thị xác nhận xóa
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hangXe = await _hangXeRepo.GetByIdAsync(id);
            if (hangXe == null)
                return NotFound();

            return View(hangXe);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> DeleteConfirmed(int HangXeID)
        {
            await _hangXeRepo.DeleteAsync(HangXeID);
            return RedirectToAction(nameof(Index));
        }
    }
}
