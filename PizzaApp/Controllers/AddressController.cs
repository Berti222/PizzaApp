using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.Controllers
{
    public class AddressController : Controller
    {
        public PizzaAppContext _context;

        public AddressController()
        {
            this._context = new PizzaAppContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        // GET: Address
        public ActionResult New(int id)
        {
            Address address = new Address();
            address.GusetId = id;
            return View(address);
        }

        public ActionResult Save(Address address)
        {
            if (address == null)
                return HttpNotFound();

            _context.Addresses.Add(address);
            _context.SaveChanges();

            Guest guest = _context.Guests.Where(g => g.Id == address.GusetId).SingleOrDefault();

            return RedirectToAction("SelectedGuest", "Ordering", new {guest});
        }
    }
}