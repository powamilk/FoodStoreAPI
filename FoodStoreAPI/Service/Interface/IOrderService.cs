using FoodStoreAPI.ViewModel;
using FoodStoreAPI.ViewModel.Order;

namespace FoodStoreAPI.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<DisplayOrderVM>> GetAllOrdersAsync();
        Task<DisplayOrderVM?> GetOrderByIdAsync(int id);
        Task<DisplayOrderVM> CreateOrderAsync(CreateOrderVM orderVM);
        Task UpdateOrderAsync(int id, EditOrderVM orderVM);
        Task DeleteOrderAsync(int id);
    }

}
