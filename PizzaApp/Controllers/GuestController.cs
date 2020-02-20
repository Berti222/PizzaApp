using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult ShowGuest(int id)
        {
            List<Address> addresses = _context.Addresses.Where(a => a.GusetId == id).ToList();
            Guest guest = _context.Guests.Where(g => g.Id == id).SingleOrDefault();
            guest.Addresses = addresses;

            if (guest == null)
                return HttpNotFound();

            return View(guest);
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