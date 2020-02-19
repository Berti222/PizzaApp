using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class Deliverer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vehicle { get; set; }

        public bool IsOnWay { get; set; }

        public List<Order> Orders { get; set; }
    }
}