using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string GuestAddress { get; set; }

        public int GusetId { get; set; }
        public Guest Gueset { get; set; }
    }
}