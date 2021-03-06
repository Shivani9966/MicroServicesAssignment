using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderAppAPIGAteway.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string RestaurantName { get; set; }
        public int RestaurantId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string DriverName { get; set; }
        public int? DriverId { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? IsOrderDelivered { get; set; }
    }
}
