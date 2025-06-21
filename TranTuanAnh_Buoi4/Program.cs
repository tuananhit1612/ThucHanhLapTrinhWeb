using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TranTuanAnh_Buoi4.Models;
using TranTuanAnh_Buoi4.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace TranTuanAnh_Buoi4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IProductRepository, EFProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            builder.Services.AddScoped<IProductImages, EFProductImages>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                     .AddDefaultTokenProviders()
                     .AddDefaultUI()
                     .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();
            app.MapRazorPages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "Admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
