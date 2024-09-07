using AutoMapper;
using FoodStoreAPI.Entities;
using FoodStoreAPI.Service.Interface;
using FoodStoreAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FoodStoreAPI.Service.Implement
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVM>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductVM>>(products);
        }

        public async Task<ProductVM?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            return _mapper.Map<ProductVM>(product);
        }

        public async Task<ProductVM> CreateProductAsync(ProductVM productVM)
        {
            var newProduct = _mapper.Map<Product>(productVM);

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVM>(newProduct);
        }

        public async Task UpdateProductAsync(int id, ProductVM productVM)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) throw new KeyNotFoundException("Product not found");

            _mapper.Map(productVM, existingProduct);
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
