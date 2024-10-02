namespace FoodStoreAPI.ViewModel.Order
{
    public class DisplayOrderVM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<DisplayOrderItemVM> OrderItems { get; set; } = new List<DisplayOrderItemVM>();
    }
}
