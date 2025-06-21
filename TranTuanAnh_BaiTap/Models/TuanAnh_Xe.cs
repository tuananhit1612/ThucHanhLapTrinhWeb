using System.ComponentModel.DataAnnotations;

namespace TranTuanAnh_BaiTap.Models
{
    public class TuanAnh_Xe
    {
        [Key]
        public int XeID { get; set; }
        public int HangXeID { get; set; }
        public string TenXe { get; set; }
        public decimal Gia { get; set; }
        public DateTime NgaySanXuat { get; set; }

        public TuanAnh_HangXe HangXe { get; set; }
    }
}
