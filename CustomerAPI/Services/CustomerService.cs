using CustomerEntities.Entities;
using CustomerEntities.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _dbContext;

        public CustomerService(CustomerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customer.ToList();
        }

        public bool AddCustomer(Customer customer)
        {
            _dbContext.Customer.Add(customer);
            _dbContext.SaveChanges();
            return true;
        }

        public Customer GetCustomerById(int id)
        {
            return _dbContext.Customer.FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateCustomer(Customer customer)
        {
            Customer data = GetCustomerById(customer.Id);
            data.FirstName = customer.FirstName;
            data.LastName = customer.LastName;
            data.Mobile = customer.Mobile;
            data.Address = customer.Address;
            _dbContext.SaveChanges();
            return true;
        }

        public bool RemoveCustomer(int id)
        {
            Customer data = _dbContext.Customer.FirstOrDefault(x => x.Id == id);
            _dbContext.Customer.Remove(data);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
