using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriverEntities.Entities.Context
{
    public class DriverContext : DbContext
    {
        public DriverContext() { }
        public DriverContext(DbContextOptions<DriverContext> options) : base(options)
        {
        }

        public virtual DbSet<Driver> Driver { get; set; }

    }
}
