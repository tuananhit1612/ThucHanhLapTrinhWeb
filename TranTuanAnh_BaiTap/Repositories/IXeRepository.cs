using TranTuanAnh_BaiTap.Models;

namespace TranTuanAnh_BaiTap.Repositories
{
    public interface IXeRepository
    {
        Task<IEnumerable<TuanAnh_Xe>> GetAllAsync();
        Task<TuanAnh_Xe> GetByIdAsync(int id);
        Task AddAsync(TuanAnh_Xe xe);
        Task UpdateAsync(TuanAnh_Xe xe);
        Task DeleteAsync(int id);
    }
}
