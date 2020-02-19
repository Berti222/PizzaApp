using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.Controllers
{
    public class OrderingController : Controller
    {
        public PizzaAppContext _context;

        public OrderingController()
        {
            this._context = new PizzaAppContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
        // GET: Ordering
        public ActionResult Index()
        {         
            
            return View();
        }

        public ActionResult SearchGuest(string guestName)
        {
            if (guestName == null)
                return HttpNotFound();

            string name = guestName.Trim().ToLower();

            List<Guest> found = _context.Guests.Where(g => g.Name.Trim().ToLower().Contains(name)).Include(g => g.Addresses).ToList();
            return View(found);
        }

        public ActionResult SearchGuest(Guest guest)
        {
            if (guest == null)
                return HttpNotFound();
            
            return View(guest);
        }

        public ActionResult PizzaOrdering(Guest guest)
        {
            Order order = new Order();

            order.GuestId = guest.Id;
            order.Guest = guest;

            return View(order);
        }
    }
}