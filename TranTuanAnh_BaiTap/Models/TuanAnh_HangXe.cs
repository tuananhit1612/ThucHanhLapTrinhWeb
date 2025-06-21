using System.ComponentModel.DataAnnotations;

namespace TranTuanAnh_BaiTap.Models
{
    public class TuanAnh_HangXe
    {
        [Key]
        public int HangXeID { get; set; }
        public string TenHang { get; set; }

        public ICollection<TuanAnh_Xe> DanhSachXe { get; set; }
    }
}

