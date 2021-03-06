using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantEntities.Entities;
using RestaurantAPI.Services;

namespace MenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;
        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Menu> Get()
        {
            return _service.GetMenu();
        }

        [HttpGet("{id}")]
        public Menu Get(int id)
        {
            return _service.GetMenuById(id);
        }

        [HttpPost]
        [Route("AddMenu")]
        public bool Add(Menu Menu)
        {
            return _service.AddMenu(Menu);
        }

        [HttpPut]
        [Route("UpdateMenu")]
        public bool Put(Menu Menu)
        {
            return _service.UpdateMenu(Menu);
        }

        [HttpPost]
        [Route("RemoveMenu")]
        public bool Delete(int id)
        {
            return _service.RemoveMenu(id);
        }
    }
}
