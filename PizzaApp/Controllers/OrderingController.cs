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

        [HttpPost]
        public ActionResult SearchGuest(Guest guestName)
        {
            string name = guestName.Name.Trim().ToLower();
            List<Guest> guests = _context.Guests.Where(g => g.Name.ToLower().Contains(name)).ToList();
            foreach (Guest guest in guests)
            {
                guest.Addresses = _context.Addresses.Where(x => x.GusetId == guest.Id).ToList();                
            }

            if (guests.Count == 0)
                return RedirectToAction("Register", "Guest");

            return View(guests);
        }

        public ActionResult PizzaOrdering(int id)
        {
            List<Address> addresses = _context.Addresses.Where(a => a.GusetId == id).ToList();

            Guest guest = _context.Guests.Where(g => g.Id == id).SingleOrDefault();

            Order order = new Order();
            OrderedPizzas orderedPizzas = new OrderedPizzas();

            order.GuestId = guest.Id;
            order.Guest = guest;

            PizzaOrderingDTO dto = new PizzaOrderingDTO()
            {
                Addresses = addresses,
                Guest = guest,
                Order = order,
                Pizzas = _context.Pizzas.ToList(),
                Deliverers = _context.Deliverers.Where(x => !x.IsOnWay).ToList(),
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

            return RedirectToAction("ChoosePizza", "Ordering", new { order.Id });
        }

        public ActionResult ChoosePizza(int id)
        {
            List<OrderedPizzas> ordered = _context.OrderedPizzas.Where(x => x.OrderId == id).ToList();
            OrderedPizzas ordering = new OrderedPizzas();
            ordering.OrderId = id;

            ChoosPizzasDTO dto = new ChoosPizzasDTO()
            {
                OrderedPizzas = ordering,
                Pizzas = _context.Pizzas.ToList(),
                Ordereds = ordered
            };
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddPizza(ChoosPizzasDTO order)
        {
            Pizza pizza = _context.Pizzas.Where(x => x.Id == order.OrderedPizzas.PizzaId).SingleOrDefault();

            if (pizza == null)
                return HttpNotFound();

            OrderedPizzas ordered = new OrderedPizzas();
            ordered.OrderId = order.OrderedPizzas.OrderId;
            ordered.Count = order.OrderedPizzas.Count;
            ordered.PizzaName = pizza.Name;
            ordered.PizzaId = pizza.Id;
            ordered.Price = pizza.Price * ordered.Count;
            
            _context.OrderedPizzas.Add(ordered);
            _context.SaveChanges();

            return RedirectToAction("ChoosePizza", new { id = ordered.OrderId });
        }

    }
}