using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class Order
    {
        [Display(Name = "Rendelés Azonosító")]
        public int Id { get; set; }
        [Display(Name = "Rendelő Neve")]
        public string Name { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        [Display(Name = "Rendelés Ideje")]
        public DateTime OrderTime { get; set; }
        [Display(Name = "Teljes Összeg")]
        public int FullPrice { get; set; }

        [Display(Name = "Szálító Azonosító")]
        public int? DelivererId { get; set; }
        public Deliverer Deliverer { get; set; }

        public List<Pizza> Pizzas { get; set; }
        [Display(Name = "Státusz")]
        public string Status { get; set; }
        [Display(Name = "Cím")]
        public string Address { get; set; }
    }
}