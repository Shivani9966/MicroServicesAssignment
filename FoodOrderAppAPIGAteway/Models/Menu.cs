using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderAppAPIGAteway.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int Price { get; set; }
        public int? Quantity { get; set; }
    }
}
