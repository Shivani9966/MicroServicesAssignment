using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderAppAPIGAteway.Models
{
    public class AssignDriverRequestModel
    {
        public int DriverId { get; set; }
        public int OrderId { get; set; }
    }
}
