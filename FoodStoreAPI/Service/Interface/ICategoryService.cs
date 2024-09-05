using FoodStoreAPI.ViewModel;

namespace FoodStoreAPI.Service.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryVM>> GetAllCategoriesAsync();
        Task<CategoryVM?> GetCategoryByIdAsync(int id);
        Task<CategoryVM> CreateCategoryAsync(CategoryVM category);
        Task UpdateCategoryAsync(int id, CategoryVM category);
        Task DeleteCategoryAsync(int id);
    }

}
