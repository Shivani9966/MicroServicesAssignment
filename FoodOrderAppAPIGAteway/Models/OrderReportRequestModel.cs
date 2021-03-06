using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderAppAPIGAteway.Models
{
    public class OrderReportRequestModel
    {
        public int RestaurantId { get; set; }
        public int DriverId { get; set; }
    }
}
