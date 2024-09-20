using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FoodStoreMVC.Models;

namespace FoodStoreMVC.Controllers
{
    public class OrderController
    {
        private readonly HttpClient _httpClient;

        public OrderController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7077")
            };
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var response = await _httpClient.GetAsync("api/orders");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Order>>(json);
            }
            return null;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/orders", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/orders/{order.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var response = await _httpClient.DeleteAsync($"api/orders/{orderId}");
            return response.IsSuccessStatusCode;
        }
    }
}
