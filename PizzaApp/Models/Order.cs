using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public DateTime OrderTime { get; set; }
        public int FullPrice { get; set; }

        public int DelivererId { get; set; }
        public Deliverer Deliverer { get; set; }

        public List<Pizza> Pizzas { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
    }
}