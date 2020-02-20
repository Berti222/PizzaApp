using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class PizzaOrderingDTO
    {
        public List<Address> Addresses { get; set; }
        public Guest Guest { get; set; }
        public Order Order { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<Deliverer> Deliverers { get; set; }
    }
}