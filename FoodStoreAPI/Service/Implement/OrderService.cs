using AutoMapper;
using FoodStoreAPI.Entities;
using FoodStoreAPI.Service.Interface;
using FoodStoreAPI.ViewModel;
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

        public async Task<IEnumerable<OrderVM>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OrderVM>>(orders);
        }

        public async Task<OrderVM?> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                                      .Include(o => o.OrderItems)
                                      .ThenInclude(oi => oi.Product)
                                      .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return null;

            return _mapper.Map<OrderVM>(order);
        }

        public async Task<OrderVM> CreateOrderAsync(OrderVM orderVM)
        {
            var newOrder = _mapper.Map<Order>(orderVM);

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderVM>(newOrder);
        }

        public async Task UpdateOrderAsync(int id, OrderVM orderVM)
        {
            var existingOrder = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrder == null) throw new KeyNotFoundException("Order not found");

            _mapper.Map(orderVM, existingOrder);
            await _context.SaveChangesAsync();
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
