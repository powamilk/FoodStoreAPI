using FoodStoreAPI.ViewModel;

namespace FoodStoreAPI.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderVM>> GetAllOrdersAsync(); 
        Task<OrderVM?> GetOrderByIdAsync(int id);
        Task<OrderVM> CreateOrderAsync(OrderVM order);
        Task UpdateOrderAsync(int id, OrderVM order);
        Task DeleteOrderAsync(int id);
    }

}
