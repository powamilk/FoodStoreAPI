using FoodStoreAPI.Entities;
using FoodStoreAPI.Service.Interface;
using FoodStoreAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FoodStoreAPI.Service.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                }).ToListAsync();
        }

        public async Task<CategoryVM?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;

            return new CategoryVM
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<CategoryVM> CreateCategoryAsync(CategoryVM category)
        {
            var newCategory = new Category
            {
                Name = category.Name,
                Description = category.Description
            };

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            category.Id = newCategory.Id;
            return category;
        }

        public async Task UpdateCategoryAsync(int id, CategoryVM category)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null) throw new KeyNotFoundException("Category not found");

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new KeyNotFoundException("Category not found");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
