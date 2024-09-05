﻿namespace FoodStoreAPI.ViewModel
{
    public class OrderItemVM
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
    }

}
