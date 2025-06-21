using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace TranTuanAnh_BaiTap.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Age { get; set; }
    }
}
