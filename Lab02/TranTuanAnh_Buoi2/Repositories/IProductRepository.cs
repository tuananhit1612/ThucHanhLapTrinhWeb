using TranTuanAnh_Buoi2.Models;
using System.Collections.Generic;
namespace TranTuanAnh_Buoi2.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Lấy về tất cả sản phẩm
        /// </summary>
        /// <returns>Danh sách Product</returns>
        IEnumerable<Product> GetAll();
        /// <summary>
        /// Lấy về sản phẩm theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product tương ứng với ID</returns>
        Product GetById(int id);
        /// <summary>
        /// Lấy về sản phẩm theo CategoryId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetByCategoryId(int id);
        /// <summary>
        /// Thêm sản phẩm mới
        /// </summary>
        /// <param name="product"></param>
        void Add(Product product);
        /// <summary>
        /// Cập nhật thông tin sản phẩm
        /// </summary>
        /// <param name="product"></param>
        void Update(Product product);

        /// <summary>
        /// Xóa sản phẩm theo ID
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

    }
}
