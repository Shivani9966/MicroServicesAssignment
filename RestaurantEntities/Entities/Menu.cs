using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantEntities.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int Price { get; set; }
        public int? Quantity { get; set; }
    }
}
