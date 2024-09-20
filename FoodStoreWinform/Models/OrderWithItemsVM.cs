using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStoreWinform.Models
{
    public class OrderWithItemsVM
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
