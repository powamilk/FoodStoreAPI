using FoodStoreAPI.Entities;
using FoodStoreAPI.Service.Interface;
using FoodStoreAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
namespace FoodStoreAPI.Service.Implement
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderVM> CreateOrderAsync(OrderVM order)
        {
            var newOrder = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.Now,
                TotalAmount = order.TotalAmount
            };

            foreach (var item in order.OrderItems)
            {
                newOrder.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            order.Id = newOrder.Id;
            return order;
        }

        public async Task<OrderVM?> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderItems)
                                             .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return null;

            return new OrderVM
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                OrderItems = order.OrderItems.Select(i => new OrderItemVM
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) throw new KeyNotFoundException("Order not found");

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }

}
