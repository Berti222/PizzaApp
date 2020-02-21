using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [Display(Name = "Név")]
        public string Name { get; set; }
        [Display(Name = "Telefonszám")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Címek")]
        public List<Address> Addresses { get; set; }
    }
}