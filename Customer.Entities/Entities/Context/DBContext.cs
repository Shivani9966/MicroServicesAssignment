using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerEntities.Entities.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() { }
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }

    }
}
