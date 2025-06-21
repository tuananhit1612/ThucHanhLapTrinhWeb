using TranTuanAnh_BaiTap.Models;

namespace TranTuanAnh_BaiTap.Repositories
{
    public interface IHangXeRepository
    {
        Task<IEnumerable<TuanAnh_HangXe>> GetAllAsync();
        Task<TuanAnh_HangXe> GetByIdAsync(int id);
        Task AddAsync(TuanAnh_HangXe hangXe);
        Task UpdateAsync(TuanAnh_HangXe hangXe);
        Task DeleteAsync(int id);
    }
}
