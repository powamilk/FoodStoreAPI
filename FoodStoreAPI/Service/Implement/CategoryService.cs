using AutoMapper;
using FoodStoreAPI.Entities;
using FoodStoreAPI.Service.Interface;
using FoodStoreAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FoodStoreAPI.Service.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryVM>>(categories);
        }

        public async Task<CategoryVM?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;

            return _mapper.Map<CategoryVM>(category);
        }

        public async Task<CategoryVM> CreateCategoryAsync(CategoryVM categoryVM)
        {
            var newCategory = _mapper.Map<Category>(categoryVM);

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryVM>(newCategory);
        }

        public async Task UpdateCategoryAsync(int id, CategoryVM categoryVM)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null) throw new KeyNotFoundException("Category not found");

            _mapper.Map(categoryVM, existingCategory);
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
