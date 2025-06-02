using TranTuanAnh_Buoi4.Models;

namespace TranTuanAnh_Buoi4.Repositories
{
    public class EFProductImages : IProductImages
    {
        private readonly ApplicationDbContext _context;
        public EFProductImages(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ProductImage productImage)
        {
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
        }
    }

 
}
