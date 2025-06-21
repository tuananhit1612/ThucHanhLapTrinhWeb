using System.ComponentModel.DataAnnotations;

namespace TranTuanAnh_BaiTap.Models
{
    public class TuanAnh_ChiTietDonHang
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int XeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public TuanAnh_DonHang Order { get; set; }
        public TuanAnh_Xe Xe { get; set; }
    }
}
