using OrderEntities.Entities;
using OrderEntities.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderContext _dbContext;

        public OrderService(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Orders> GetOrders()
        {
            return _dbContext.Orders.ToList();
        }

        public bool AddOrder(Orders Order)
        {
            Order.OrderDate = DateTime.Now;
            Order.IsOrderDelivered = false;
            _dbContext.Orders.Add(Order);
            _dbContext.SaveChanges();
            return true;
        }

        public Orders GetOrderById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateOrder(Orders Order)
        {
            Orders data = GetOrderById(Order.Id);
            data.OrderNumber = Order.OrderNumber;
            data.Price = Order.Price;
            data.RestaurantName = Order.RestaurantName;
            data.Quantity = Order.Quantity;
            data.IsOrderDelivered = Order.IsOrderDelivered;
            data.DriverId = Order.DriverId;
            data.DriverName = Order.DriverName;
            _dbContext.SaveChanges();
            return true;
        }

        public bool RemoveOrder(int id)
        {
            Orders data = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
            _dbContext.Orders.Remove(data);
            _dbContext.SaveChanges();
            return true;
        }

        /// <summary>
        /// Get all orders for specific customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Orders> GetOrderByCustomerId(int customerId)
        {
            return _dbContext.Orders.Where(x => x.CustomerId == customerId).ToList();
        }

        /// <summary>
        /// Get all orders for specific restaurant
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public List<Orders> GetOrderByRestaurantId(int restaurantId)
        {
            return _dbContext.Orders.Where(x => x.RestaurantId == restaurantId).ToList();
        }

        /// <summary>
        /// Get all orders for specific driver
        /// </summary>
        /// <param name="driverId"></param>
        /// <returns></returns>
        public List<Orders> GetOrderByDriverId(int driverId)
        {
            return _dbContext.Orders.Where(x => x.DriverId == driverId).ToList();
        }
    }
}
