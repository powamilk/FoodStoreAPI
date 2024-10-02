namespace FoodStoreAPI.ViewModel.Order
{
    public class EditOrderVM
    {
        public int CustomerId { get; set; }
        public List<EditOrderItemVM> OrderItems { get; set; } = new List<EditOrderItemVM>();
    }
}
