using FoodStoreAPI.Entities;

namespace FoodStoreAPI.ViewModel
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemVM> OrderItems { get; set; } = new List<OrderItemVM>();
    }

}
