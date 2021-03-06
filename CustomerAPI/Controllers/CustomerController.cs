using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerEntities.Entities;
using CustomerAPI.Services;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _service.GetCustomers();
        }

        [HttpGet]
        [Route("GetCustomerById")]
        public Customer Get(int id)
        {
            return _service.GetCustomerById(id);
        }

        [HttpPost]
        [Route("AddCustomer")]
        public bool Add(Customer customer)
        {
            return _service.AddCustomer(customer);
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public bool Put(Customer customer)
        {
            return _service.UpdateCustomer(customer);
        }

        [HttpPost]
        [Route("RemoveCustomer")]
        public bool Delete(int id)
        {
            return _service.RemoveCustomer(id);
        }
    }
}
