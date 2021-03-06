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
    public class DriverController : ControllerBase
    {
        Httpclient httpclient = new Httpclient();

        /// <summary>
        /// Get current(pending) orders for Driver
        /// </summary>
        /// <param name="driverId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCurrentOrders")]
        public async Task<List<Orders>> GetAllCurrentOrders(int driverId)
        {
            List<Orders> orders = await httpclient.RunAsyncGet<int, List<Orders>>("https://localhost:44336/api/Order/GetOrderByDriverId", driverId);
            return orders.Where(x => x.IsOrderDelivered == false).ToList();
        }

        /// <summary>
        /// Get Delivered orders for Driver
        /// </summary>
        /// <param name="driverId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDeliveredOrders")]
        public async Task<List<Orders>> GetAllDeliveredOrders(int driverId)
        {
            List<Orders> orders = await httpclient.RunAsyncGet<int, List<Orders>>("https://localhost:44336/api/Order/GetOrderByDriverId", driverId);
            return orders.Where(x => x.IsOrderDelivered == true).ToList();
        }

        /// <summary>
        /// Get all orders for Driver
        /// </summary>
        /// <param name="driverId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOrders")]
        public async Task<List<Orders>> GetAllOrders(int driverId)
        {
            return await httpclient.RunAsyncGet<int, List<Orders>>("https://localhost:44336/api/Order/GetOrderByDriverId", driverId);
        }
    }
}
