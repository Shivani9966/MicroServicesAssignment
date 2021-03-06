using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderEntities.Entities.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext() { }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public virtual DbSet<Orders> Orders { get; set; }

    }
}
