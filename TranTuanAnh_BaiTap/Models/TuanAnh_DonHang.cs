using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranTuanAnh_BaiTap.Models
{
    public class TuanAnh_DonHang
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public string Notes { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public List<TuanAnh_ChiTietDonHang> OrderDetails { get; set; }

    }
}
