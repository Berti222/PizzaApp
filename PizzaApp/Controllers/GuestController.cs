using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.Controllers
{
    public class GuestController : Controller
    {

        public PizzaAppContext _context;

        public GuestController()
        {
            this._context = new PizzaAppContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Save(Guest guest)
        {
            if (guest == null)
                return HttpNotFound();

            _context.Guests.Add(guest);
            _context.SaveChanges();

            return RedirectToAction("New", "Address", new { guest.Id });
        }
    }
}