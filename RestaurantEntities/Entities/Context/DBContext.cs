using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantEntities.Entities.Context
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() { }
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }

        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }

    }
}
