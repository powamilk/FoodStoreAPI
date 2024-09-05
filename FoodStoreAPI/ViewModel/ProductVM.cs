﻿namespace FoodStoreAPI.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
    }

}
