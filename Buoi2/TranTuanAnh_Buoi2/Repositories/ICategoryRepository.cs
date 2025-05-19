using TranTuanAnh_Buoi2.Models;

namespace TranTuanAnh_Buoi2.Repositories
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Lấy về tất cả danh mục
        /// </summary>
        /// <returns>Danh sách tất cả Categories</returns>
        IEnumerable<Category> GetAllCategories();

        Category GetById(int id);
        /// <summary>
        /// Thêm sản phẩm mới
        /// </summary>
        /// <param name="product"></param>
        void Add(Category category);
        /// <summary>
        /// Cập nhật thông tin sản phẩm
        /// </summary>
        /// <param name="product"></param>
        void Update(Category category);

        /// <summary>
        /// Xóa sản phẩm theo ID
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
