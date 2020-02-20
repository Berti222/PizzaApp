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

        [HttpPost]
        public ActionResult SearchGuest(Guest guestName)
        {
            string name = guestName.Name;
            List<Guest> guests = _context.Guests.Where(g => g.Name == name).Include(g => g.Addresses).ToList();

            if (guests.Count == 0)
                return HttpNotFound();

            return View(guests);
        }

        public ActionResult PizzaOrdering(int id)
        {
            List<Address> addresses = _context.Addresses.Where(a => a.GusetId == id).ToList();

            Guest guest = _context.Guests.Where(g => g.Id == id).SingleOrDefault();

            Order order = new Order();

            order.GuestId = guest.Id;
            order.Guest = guest;

            PizzaOrderingDTO dto = new PizzaOrderingDTO()
            {
                Addresses = addresses,
                Guest = guest,
                Order = order,
                Pizzas = _context.Pizzas.ToList(),
                Deliverers = _context.Deliverers.Where(x => !x.IsOnWay).ToList()
            };

            return View(dto);
        }

        [HttpPost]
        public ActionResult Order(PizzaOrderingDTO dto)
        {
            Order order = new Order();

            order.Address = dto.Order.Address;
            order.Name = dto.Guest.Name;
            order.GuestId = dto.Guest.Id;
            order.Guest = dto.Guest;
            order.DelivererId = dto.Order.DelivererId;
            order.OrderTime = DateTime.Now;
            order.Status = StatusName.VaitingForDelivering;

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }


    }
}