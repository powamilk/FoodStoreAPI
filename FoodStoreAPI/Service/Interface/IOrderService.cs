using FoodStoreAPI.ViewModel;

namespace FoodStoreAPI.Service.Interface
{
    public interface IOrderService
    {
        Task<OrderVM> CreateOrderAsync(OrderVM order);
        Task<OrderVM?> GetOrderByIdAsync(int id);
        Task DeleteOrderAsync(int id);
    }

}
