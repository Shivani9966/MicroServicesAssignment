using DriverAPI.Services;
using DriverEntities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _service;
        public DriverController(IDriverService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            return _service.GetDrivers();
        }

        [HttpGet]
        [Route("GetDriverById")]
        public Driver Get(int id)
        {
            return _service.GetDriverById(id);
        }

        [HttpPost]
        [Route("AddDriver")]
        public bool Add(Driver Driver)
        {
            return _service.AddDriver(Driver);
        }

        [HttpPut]
        [Route("UpdateDriver")]
        public bool Put(Driver Driver)
        {
            return _service.UpdateDriver(Driver);
        }

        [HttpPost]
        [Route("RemoveDriver")]
        public bool Delete(int id)
        {
            return _service.RemoveDriver(id);
        }
    }
}
