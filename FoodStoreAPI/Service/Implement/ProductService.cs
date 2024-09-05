using FoodStoreAPI.Entities;
using FoodStoreAPI.Service.Interface;
using FoodStoreAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
namespace FoodStoreAPI.Service.Implement
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductVM>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    Price = p.Price,
                    Description = p.Description,
                    Stock = p.Stock
                }).ToListAsync();
        }

        public async Task<ProductVM> CreateProductAsync(ProductVM product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Description = product.Description,
                Stock = product.Stock
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            product.Id = newProduct.Id;
            return product;
        }

        public async Task UpdateProductAsync(int id, ProductVM product)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) throw new KeyNotFoundException("Product not found");

            existingProduct.Name = product.Name;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.Stock = product.Stock;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new KeyNotFoundException("Product not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

}
