using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderAppAPIGAteway.Models
{
    public class OrderRequestModel
    {
        public int CustomerId { get; set; }
        public string RestaurantName { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
