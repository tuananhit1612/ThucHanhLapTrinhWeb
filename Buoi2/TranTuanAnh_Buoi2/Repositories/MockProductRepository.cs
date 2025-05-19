namespace TranTuanAnh_Buoi2.Repositories;
using TranTuanAnh_Buoi2.Models;
using System.Linq;
using System.Collections.Generic;


public class MockProductRepository : IProductRepository
{
    private readonly List<Product> _products;
    public MockProductRepository()
    {
        // Tạo một số dữ liệu mẫu
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", ImageUrl="/images/laptop.jpg", Price = 1000, Description = "A high-end laptop", CategoryId = 1 },
            new Product { Id = 2, Name = "Smartphone",ImageUrl="/images/Smartphone.jpg", Price = 700, Description = "Latest model smartphone", CategoryId = 2 },
            new Product { Id = 3, Name = "Tablet",ImageUrl="/images/Tablet.png", Price = 400, Description = "10-inch display tablet", CategoryId = 2 },
            new Product { Id = 4, Name = "Wireless Mouse",ImageUrl="/images/mouse.png", Price = 25, Description = "Ergonomic wireless mouse", CategoryId = 3 },
            new Product { Id = 5, Name = "Mechanical Keyboard",ImageUrl="/images/Keyboard.png", Price = 80, Description = "RGB mechanical keyboard", CategoryId = 3 },
            new Product { Id = 6, Name = "Monitor", Price = 200,ImageUrl="/images/screen.png", Description = "24-inch Full HD monitor", CategoryId = 4 },
            new Product { Id = 7, Name = "External SSD",ImageUrl="/images/ssd.png", Price = 120, Description = "1TB portable SSD", CategoryId = 5 }
        };

    }
    public Product GetByCategoryId(int id)
    {
        return _products.FirstOrDefault(p => p.CategoryId == id);
    }
    public IEnumerable<Product> GetAll()
    {
        return _products;
    }
    public Product GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
    public void Add(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
    }
    public void Update(Product product)
    {
        var index = _products.FindIndex(p => p.Id == product.Id);
        if (index != -1)
        {
            _products[index] = product;
        }
    }

    public void Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }

}

