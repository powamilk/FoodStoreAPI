namespace FoodStoreAPI.ViewModel
{
    public class UpdateOrderVM
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemVM> OrderItems { get; set; } = new List<OrderItemVM>();
    }
}
