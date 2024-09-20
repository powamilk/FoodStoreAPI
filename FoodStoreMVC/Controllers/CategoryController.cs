using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FoodStoreMVC.Models;

namespace FoodStoreMVC.Controllers
{
    public class CategoryController
    {
        private readonly HttpClient _httpClient;

        public CategoryController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7077")
            };
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("api/categories");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Category>>(json);
            }
            return null;
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/categories", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/categories/{category.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var response = await _httpClient.DeleteAsync($"api/categories/{categoryId}");
            return response.IsSuccessStatusCode;
        }
    }
}
