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

        public async Task<IEnumerable<OrderVM>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Select(o => new OrderVM
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemVM
                    {
                        ProductId = oi.ProductId,
                        Quantity = oi.Quantity,
                        ProductName = oi.Product.Name,
                        ProductPrice = oi.Product.Price 
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<OrderVM?> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                                      .Include(o => o.OrderItems)
                                      .ThenInclude(oi => oi.Product)
                                      .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return null;
            }

            return new OrderVM
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                OrderItems = order.OrderItems.Select(oi => new OrderItemVM
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    ProductName = oi.Product.Name,
                    ProductPrice = oi.Product.Price
                }).ToList()
            };
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

        public async Task UpdateOrderAsync(int id, OrderVM order)
        {
            var existingOrder = await _context.Orders.Include(o => o.OrderItems)
                                                     .FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrder == null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            existingOrder.CustomerId = order.CustomerId;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.TotalAmount = order.TotalAmount;
            existingOrder.OrderItems.Clear();
            foreach (var item in order.OrderItems)
            {
                existingOrder.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
