using FoodOrderAppAPIGAteway.Models;
using FoodOrderAppAPIGAteway.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderAppAPIGAteway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        Httpclient httpclient = new Httpclient();
        
        /// <summary>
        /// Get All Restaurants List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllResturants")]
        //[Authorize]
        public async Task<List<Restaurant>> GetAllResturant()
        {
            var accessToken1 = Request.Headers[HeaderNames.Authorization];
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                // or
                //identity.FindFirst("ClaimName").Value;
                ValidateToken("token");
                var accessToken = await HttpContext.GetTokenAsync("access_token");
            }
            return await httpclient.RunAsyncGetAll<Restaurant>("https://localhost:44328/api/Restaurant");
        }

        /// <summary>
        /// Order Food from Customer
        /// </summary>
        /// <param name="orderRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("OrderFood")]
        public async Task<bool> OrderFood(OrderRequestModel orderRequest)
        {
            Customer customer = await httpclient.RunAsyncGet<int, Customer>("https://localhost:44351/api/Customer/GetCustomerById", orderRequest.CustomerId);
            Orders order = new Orders{
                CustomerName = customer.FirstName + ' ' +customer.LastName,
                RestaurantName = orderRequest.RestaurantName,
                Price = orderRequest.Price,
                Quantity = orderRequest.Quantity
            };
            return await httpclient.RunAsyncPost<Orders, bool>("https://localhost:44336/api/Order/AddOrder", order); 
        }

        /// <summary>
        /// Get current orders for customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllCurrentOrders")]
        public async Task<List<Orders>> GetAllCurrentOrders(int customerId)
        {
            List<Orders> orders = await httpclient.RunAsyncGet<int, List<Orders>>("https://localhost:44336/api/Order/GetOrderByCustomerId", customerId);
            if(orders != null && orders.Count > 0)
                return orders.Where(x => x.IsOrderDelivered == false).ToList();
            return null;
        }

        /// <summary>
        /// Get delivered orders for customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllDeliveredOrders")]
        public async Task<List<Orders>> GetAllDeliveredOrders(int customerId)
        {
            List<Orders> orders = await httpclient.RunAsyncGet<int, List<Orders>>("https://localhost:44336/api/Order/GetOrderByCustomerId", customerId);
            if (orders != null && orders.Count > 0)
                return orders.Where(x => x.IsOrderDelivered == true).ToList();
            return null;
        }

        public static ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = "http://localhost:36547".ToLower();
            validationParameters.ValidIssuer = "http://localhost:36547".ToLower();
            validationParameters.IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKeyqazxswedcmlpokn12#@!07"));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);


            return principal;
        }
    }
}
