using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStoreWinform.Models
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity {  get; set; }
        public string ProductName { get; set; } 
        public float ProductPrice { get; set; }
    }
}
