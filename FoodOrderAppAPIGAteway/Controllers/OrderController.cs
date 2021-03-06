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
    public class OrderController : ControllerBase
    {
        Httpclient httpclient = new Httpclient();

        /// <summary>
        /// AssignDriver for Order
        /// </summary>
        /// <param name="orderRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AssignDriver")]
        public async Task<bool> AssignDriver(AssignDriverRequestModel request)
        {
            Orders order = await httpclient.RunAsyncGet<int, Orders>("https://localhost:44336/api/Order/GetOrderById", request.OrderId);
            Driver driver = await httpclient.RunAsyncGet<int, Driver>("https://localhost:44343/api/Driver/GetDriverById", request.DriverId);
            order.DriverName = driver.FirstName + ' ' + driver.LastName;
            order.DriverId = request.DriverId;
            return await httpclient.RunAsyncPut<Orders, bool>("https://localhost:44336/api/Order/UpdateOrder", order);
        }

        /// <summary>
        /// Order status change from notdelivered to delivered
        /// </summary>
        /// <param name="orderRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("OrderDelivered")]
        public async Task<bool> OrderDelivered(int orderId)
        {
            Orders order = await httpclient.RunAsyncGet<int, Orders>("https://localhost:44336/api/Order/GetOrderById", orderId);
            if(order != null)
            {
                order.IsOrderDelivered = true;
                return await httpclient.RunAsyncPut<Orders, bool>("https://localhost:44336/api/Order/UpdateOrder", order);
            }
            return false;
        }
    }
}
