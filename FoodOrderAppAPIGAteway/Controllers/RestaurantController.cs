using FoodOrderAppAPIGAteway.Models;
using FoodOrderAppAPIGAteway.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderAppAPIGAteway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        Httpclient httpclient = new Httpclient();

        /// <summary>
        /// Get current orders for Restaurant
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<List<Orders>> GetAllCurrentOrders(int restaurantId)
        {
            return await httpclient.RunAsyncGet<int, List<Orders>>("https://localhost:44336/api/Order/GetOrderByRestaurantId", restaurantId);
        }

        /// <summary>
        /// Get monthly report for orders
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMonthlyOrderReport")]
        public async Task<List<Orders>> GetMonthlyOrderReport(int restaurantId)
        {
            List<Orders> orders = await httpclient.RunAsyncGet<int, List<Orders>>("https://localhost:44336/api/Order/GetOrderByRestaurantId", restaurantId);
            return orders.Where(x => x.IsOrderDelivered == true && (DateTime.Now - x.OrderDate.Value).TotalDays <= 30).ToList();
        }

        /// <summary>
        /// Get 2 month report for orders filter by driver
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetOrderReportDriver")]
        public async Task<List<Orders>> GetOrderReportFilterByDriver(OrderReportRequestModel reportRequest)
        {
            List<Orders> orders = await httpclient.RunAsyncGet<int, List<Orders>>("https://localhost:44336/api/Order/GetOrderByRestaurantId", reportRequest.RestaurantId);
            return orders.Where(x => x.DriverId == reportRequest.DriverId && x.IsOrderDelivered == true && (DateTime.Now - x.OrderDate.Value).TotalDays <= 61).ToList();
        }
    }
}
