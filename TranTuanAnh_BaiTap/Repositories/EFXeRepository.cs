using TranTuanAnh_BaiTap.Models;
using Microsoft.EntityFrameworkCore;
namespace TranTuanAnh_BaiTap.Repositories
{
    public class EFXeRepository : IXeRepository
    {
        private readonly ApplicationDbContext _context;

        public EFXeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TuanAnh_Xe>> GetAllAsync()
        {
            return await _context.TuanAnh_Xe.Include(x => x.HangXe).ToListAsync();
        }

        public async Task<TuanAnh_Xe> GetByIdAsync(int id)
        {
            return await _context.TuanAnh_Xe.Include(x => x.HangXe).FirstOrDefaultAsync(x => x.XeID == id);
        }

        public async Task AddAsync(TuanAnh_Xe xe)
        {
            _context.TuanAnh_Xe.Add(xe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TuanAnh_Xe xe)
        {
            _context.TuanAnh_Xe.Update(xe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var xe = await _context.TuanAnh_Xe.FindAsync(id);
            if (xe != null)
            {
                _context.TuanAnh_Xe.Remove(xe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
