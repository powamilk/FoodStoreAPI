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

        public async Task<IEnumerable<ProductVM>> GetAllProductsAsync()
        {
            return await _context.Products
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

        public async Task<ProductVM?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            return new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Description = product.Description,
                Stock = product.Stock
            };
        }

        public async Task<ProductVM> CreateProductAsync(ProductVM productVM)
        {
            var newProduct = new Product
            {
                Name = productVM.Name,
                CategoryId = productVM.CategoryId,
                Price = productVM.Price,
                Description = productVM.Description,
                Stock = productVM.Stock
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            productVM.Id = newProduct.Id;
            return productVM;
        }

        public async Task UpdateProductAsync(int id, ProductVM productVM)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            existingProduct.Name = productVM.Name;
            existingProduct.CategoryId = productVM.CategoryId;
            existingProduct.Price = productVM.Price;
            existingProduct.Description = productVM.Description;
            existingProduct.Stock = productVM.Stock;

            await _context.SaveChangesAsync();
        }


        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }


}
