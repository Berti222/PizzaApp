using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PizzaApp.Models
{
    public class PizzaAppContext : DbContext
    {
        public PizzaAppContext()
            :base("name=DefaultConnection")
        {
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Deliverer> Deliverers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedPizzas> OrderedPizzas { get; set; }

    }
}