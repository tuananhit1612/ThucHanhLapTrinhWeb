using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TranTuanAnh_BaiTap.Models;
namespace TranTuanAnh_BaiTap.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<TuanAnh_Xe> TuanAnh_Xe { get; set; }
        public DbSet<TuanAnh_HangXe> TuanAnh_HangXe { get; set; }
        public DbSet<TuanAnh_DonHang> TuanAnh_DonHang { get; set; }
        public DbSet<TuanAnh_ChiTietDonHang> TuanAnh_ChiTietDonHang { get; set; }



    }
}
