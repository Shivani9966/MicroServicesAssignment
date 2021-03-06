using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantEntities.Entities;
using RestaurantAPI.Services;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<RestaurantResponseModel> Get()
        {
            return _service.GetRestaurants();
        }

        [HttpGet]
        [Route("GetRestaurantById")]
        public Restaurant Get(int id)
        {
            return _service.GetRestaurantById(id);
        }

        [HttpPost]
        [Route("AddRestaurant")]
        public bool Add(Restaurant Restaurant)
        {
            return _service.AddRestaurant(Restaurant);
        }

        [HttpPut]
        [Route("UpdateRestaurant")]
        public bool Put(Restaurant Restaurant)
        {
            return _service.UpdateRestaurant(Restaurant);
        }

        [HttpPost]
        [Route("RemoveRestaurant")]
        public bool Delete(int id)
        {
            return _service.RemoveRestaurant(id);
        }
    }
}
