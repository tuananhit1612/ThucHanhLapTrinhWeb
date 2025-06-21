using Microsoft.EntityFrameworkCore;
using TranTuanAnh_BaiTap.Models;

namespace TranTuanAnh_BaiTap.Repositories
{
    public class EFHangXeRepository : IHangXeRepository
    {
        private readonly ApplicationDbContext _context;

        public EFHangXeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TuanAnh_HangXe>> GetAllAsync()
        {
            return await _context.TuanAnh_HangXe
                                 .Include(h => h.DanhSachXe)
                                 .ToListAsync();
        }

        public async Task<TuanAnh_HangXe> GetByIdAsync(int id)
        {
            return await _context.TuanAnh_HangXe
                                 .Include(h => h.DanhSachXe)
                                 .FirstOrDefaultAsync(h => h.HangXeID == id);
        }

        public async Task AddAsync(TuanAnh_HangXe hangXe)
        {
            _context.TuanAnh_HangXe.Add(hangXe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TuanAnh_HangXe hangXe)
        {
            _context.TuanAnh_HangXe.Update(hangXe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hangXe = await _context.TuanAnh_HangXe.FindAsync(id);
            if (hangXe != null)
            {
                _context.TuanAnh_HangXe.Remove(hangXe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
