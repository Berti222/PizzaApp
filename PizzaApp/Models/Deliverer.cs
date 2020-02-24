using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class Deliverer
    {
        public int Id { get; set; }
        [Display(Name ="Futár neve")]
        public string Name { get; set; }
        [Display(Name = "Jármű")]
        public string Vehicle { get; set; }
        [Display(Name = "Úton van?")]
        public bool IsOnWay { get; set; }
        [Display(Name = "Kapacítás")]
        public int Capacity { get; set; }
        [Display(Name = "Tele van?")]
        public bool IsFull { get; set; }

    }
}