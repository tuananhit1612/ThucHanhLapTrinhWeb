using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TranTuanAnh_BaiTap.Areas.Admin.Models;
using TranTuanAnh_BaiTap.Models;
using TranTuanAnh_BaiTap.Repositories;

namespace TranTuanAnh_BaiTap.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class TuanAnh_XeController : Controller
    {
        private readonly IXeRepository _xeRepo;
        private readonly IHangXeRepository _hangXeRepo;

        public TuanAnh_XeController(IXeRepository xeRepo, IHangXeRepository hangXeRepo)
        {
            _xeRepo = xeRepo;
            _hangXeRepo = hangXeRepo;
        }
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Details(int id)
        {
            var Xe = await _xeRepo.GetByIdAsync(id);
            if (Xe == null)
                return NotFound();

            return View(Xe);
        }
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Index(string search)
        {
            var xes = await _xeRepo.GetAllAsync();
            if (!string.IsNullOrEmpty(search))
                xes = xes.Where(x => x.TenXe.Contains(search)).ToList();

            return View(xes);
        }
        [Authorize(Roles = $"{SD.Role_Admin}")]

        public async Task<IActionResult> Create()
        {
            ViewBag.HangXeList = new SelectList(await _hangXeRepo.GetAllAsync(), "HangXeID", "TenHang");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Create(TuanAnh_Xe xe)
        {
            await _xeRepo.AddAsync(xe);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Edit(int id)
        {
            var xe = await _xeRepo.GetByIdAsync(id);
            if (xe == null) return NotFound();

            ViewBag.HangXeList = new SelectList(await _hangXeRepo.GetAllAsync(), "HangXeID", "TenHang", xe.HangXeID);
            return View(xe);
        }

        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Edit(TuanAnh_Xe xe)
        {
                await _xeRepo.UpdateAsync(xe);
                return RedirectToAction("Index");
        }

        [Authorize(Roles = $"{SD.Role_Admin}")]
        public async Task<IActionResult> Delete(int id)
        {
            var xe = await _xeRepo.GetByIdAsync(id);
            if (xe == null) return NotFound();
            return View(xe);
        }

        [Authorize(Roles = $"{SD.Role_Admin}")]
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int XeID)
        {
            await _xeRepo.DeleteAsync(XeID);
            return RedirectToAction("Index");
        }
    }
}
