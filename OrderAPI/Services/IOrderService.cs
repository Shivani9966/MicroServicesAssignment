using OrderEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Services
{
    public interface IOrderService
    {
        IEnumerable<Orders> GetOrders();
        bool AddOrder(Orders Order);
        Orders GetOrderById(int id);
        bool UpdateOrder(Orders Order);
        bool RemoveOrder(int id);
        List<Orders> GetOrderByCustomerId(int customerId);
        List<Orders> GetOrderByRestaurantId(int restaurantId);
        List<Orders> GetOrderByDriverId(int driverId);
    }
}
