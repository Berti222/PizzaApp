using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class OrderedPizzas
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        [Display(Name ="Rendelési azonosító")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Display(Name ="Pizza fajta")]
        public string PizzaName { get; set; }

        [Display(Name = "Pizza ára")]
        public int Price { get; set; }

        [Display(Name = "Darab")]
        public int Count { get; set; }
    }
}