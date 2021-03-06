using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class RestaurantResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string FoodName { get; set; }
        public int Price { get; set; }
        public int? Quantity { get; set; }
        public int? MenuId { get; set; }
    }
}
