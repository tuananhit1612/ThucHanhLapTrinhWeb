using System.ComponentModel.DataAnnotations;

namespace TranTuanAnh_Buoi2.Models
{
    public class Category
    {
        public int Id { get; set; } // id của danh mục
        [Required, StringLength(50)] // required là bắt buộc, StringLength là độ dài tối đa
        public string Name { get; set; } // tên danh mục
    }
}
