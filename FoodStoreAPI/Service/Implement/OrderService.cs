using AutoMapper;
using FoodStoreAPI.Entities;
using FoodStoreAPI.Service.Interface;
using FoodStoreAPI.ViewModel;
using FoodStoreAPI.ViewModel.Order;
using Microsoft.EntityFrameworkCore;

namespace FoodStoreAPI.Service.Implement
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DisplayOrderVM>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();

            return _mapper.Map<IEnumerable<DisplayOrderVM>>(orders);
        }

        public async Task<DisplayOrderVM?> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                                      .Include(o => o.OrderItems)
                                      .ThenInclude(oi => oi.Product)
                                      .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return null;

            return _mapper.Map<DisplayOrderVM>(order);
        }

        public async Task<DisplayOrderVM> CreateOrderAsync(CreateOrderVM orderVM)
        {
            var newOrder = new Order
            {
                CustomerId = orderVM.CustomerId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = 0, 
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in orderVM.OrderItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                    throw new KeyNotFoundException($"Product with id {item.ProductId} not found");

                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Order = newOrder
                };

                newOrder.OrderItems.Add(orderItem);
                newOrder.TotalAmount += product.Price * item.Quantity;
            }

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return _mapper.Map<DisplayOrderVM>(newOrder);
        }

        public async Task UpdateOrderAsync(int id, EditOrderVM orderVM)
        {
            var existingOrder = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrder == null)
                return;

            existingOrder.CustomerId = orderVM.CustomerId;
            existingOrder.OrderDate = DateTime.UtcNow;

            _context.OrderItems.RemoveRange(existingOrder.OrderItems);
            existingOrder.OrderItems.Clear();

            foreach (var item in orderVM.OrderItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                    throw new KeyNotFoundException($"Product with ID {item.ProductId} not found");

                var newOrderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Order = existingOrder
                };

                existingOrder.OrderItems.Add(newOrderItem);
            }
            existingOrder.TotalAmount = existingOrder.OrderItems
                .Sum(item => item.Product?.Price * item.Quantity ?? 0);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems) 
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                throw new KeyNotFoundException("Order not found");

            _context.OrderItems.RemoveRange(order.OrderItems);

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
        }

    }
}
