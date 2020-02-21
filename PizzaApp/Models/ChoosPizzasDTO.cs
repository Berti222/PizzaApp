using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class ChoosPizzasDTO
    {
        public OrderedPizzas OrderedPizzas { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<OrderedPizzas> Ordereds { get; set; }

    }
}