using CustomerEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        bool AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        bool UpdateCustomer(Customer customer);
        bool RemoveCustomer(int id);
    }
}
