namespace FoodStoreAPI.ViewModel.Order
{
    public class CreateOrderVM
    {
        public int CustomerId { get; set; }
        public List<CreateOrderItemVM> OrderItems { get; set; } = new List<CreateOrderItemVM>();
    }
}
