using TranTuanAnh_Buoi2.Models;

namespace TranTuanAnh_Buoi2.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<Category> _categoryList;
        public MockCategoryRepository()
        {
            _categoryList = new List<Category>
            {
                new Category { Id = 1, Name = "Laptop" },
                new Category { Id = 2, Name = "Mobile Devices" },
                new Category { Id = 3, Name = "Accessories" },
                new Category { Id = 4, Name = "Monitor" },
                new Category { Id = 5, Name = "Storage" }
            };
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryList;
        }
        public Category GetById(int id)
        {
            return _categoryList.FirstOrDefault(c => c.Id == id);
        }
        public void Add(Category category)
        {
            category.Id = _categoryList.Max(c => c.Id) + 1;
            _categoryList.Add(category);
        }
        public void Update(Category category)
        {
            var index = _categoryList.FindIndex(c => c.Id == category.Id);
            if (index != -1)
            {
                _categoryList[index] = category;
            }
        }
        public void Delete(int id)
        {
            var category = _categoryList.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _categoryList.Remove(category);
            }
        }
    }
}
