using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderEntities.Entities;
using OrderAPI.Services;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            return _service.GetOrders();
        }

        [HttpGet]
        [Route("GetOrderById")]
        public Orders Get(int id)
        {
            return _service.GetOrderById(id);
        }

        [HttpPost]
        [Route("AddOrder")]
        public bool Add(Orders Order)
        {
            return _service.AddOrder(Order);
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public bool Put(Orders Order)
        {
            return _service.UpdateOrder(Order);
        }

        [HttpPost]
        [Route("RemoveOrder")]
        public bool Delete(int id)
        {
            return _service.RemoveOrder(id);
        }

        [HttpGet]
        [Route("GetOrderByCustomerId")]
        public List<Orders> GetOrderByCustomerId(int id)
        {
            return _service.GetOrderByCustomerId(id);
        }

        [HttpGet]
        [Route("GetOrderByRestaurantId")]
        public List<Orders> GetOrderByRestaurantId(int id)
        {
            return _service.GetOrderByRestaurantId(id);
        }

        [HttpGet]
        [Route("GetOrderByDriverId")]
        public List<Orders> GetOrderByDriverId(int id)
        {
            return _service.GetOrderByDriverId(id);
        }
    }
}
