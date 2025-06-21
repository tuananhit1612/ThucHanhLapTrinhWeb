using System.ComponentModel.DataAnnotations;

namespace TranTuanAnh_Buoi2.Models
{
    public class Product
    {
        public int Id { get; set; } // id của sản phẩm
        [Required, StringLength(100)] // required là bắt buộc, StringLength là độ dài tối đa
        public string Name { get; set; } // tên sản phẩm
        [Range(0.01, 10000.00)] // range là khoảng giá trị min-max
        public decimal Price { get; set; } // giá sản phẩm
        public string Description { get; set; } // mô tả sản phẩm
        public int CategoryId { get; set; } // id của danh mục
        public String ImageUrl { get; set; } // đường dẫn đến hình ảnh sản phẩm
        public List<String> ImageUrls { get; set; } // đường dẫn đến hình ảnh sản phẩm
    }
}
