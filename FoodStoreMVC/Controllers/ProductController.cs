using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FoodStoreMVC.Models;

namespace FoodStoreMVC.Controllers
{
    public class ProductController
    {
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7077")
            };
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/products");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Product>>(json);
            }
            return null;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/products", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/products/{product.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var response = await _httpClient.DeleteAsync($"api/products/{productId}");
            return response.IsSuccessStatusCode;
        }
    }
}
