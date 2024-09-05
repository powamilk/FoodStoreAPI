using FoodStoreAPI.ViewModel;

namespace FoodStoreAPI.Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductVM>> GetAllProductsAsync();
        Task<ProductVM?> GetProductByIdAsync(int id);
        Task<ProductVM> CreateProductAsync(ProductVM product);
        Task UpdateProductAsync(int id, ProductVM product);
        Task DeleteProductAsync(int id);
    }

}
