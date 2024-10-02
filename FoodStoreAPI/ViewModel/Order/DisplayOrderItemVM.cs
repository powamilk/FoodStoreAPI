namespace FoodStoreAPI.ViewModel.Order
{
    public class DisplayOrderItemVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
