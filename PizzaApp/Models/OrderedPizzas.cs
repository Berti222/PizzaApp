using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class OrderedPizzas
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string PizzaName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}