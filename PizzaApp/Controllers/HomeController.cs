using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        public PizzaAppContext _context;

        public HomeController()
        {
            this._context = new PizzaAppContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActiveOrders()
        {
            List<Order> orders = _context
                                .Orders
                                .Where(o => o.Status == StatusName.VaitingForDelivering
                                || o.Status == StatusName.Active)
                                .Include(o => o.Guest)
                                .Include(o => o.Deliverer)
                                .ToList();
            return View(orders);
        }

        public ActionResult AssignDeliverer(int id)
        {
            Order order = _context.Orders.Where(o => o.Id == id).SingleOrDefault();
            List<Deliverer> deliverers = _context.Deliverers.ToList();

            PizzaOrderingDTO dto = new PizzaOrderingDTO();
            dto.Order = order;
            dto.Deliverers = deliverers;

            return View(dto);
        }

        [HttpPost]
        public ActionResult Assign(PizzaOrderingDTO dto)
        {
            Order order = _context.Orders.Where(o => o.Id == dto.Order.Id).SingleOrDefault();
            order.DelivererId = dto.Order.DelivererId;
            Deliverer deliverer = _context.Deliverers.Where(d => d.Id == dto.Order.DelivererId).SingleOrDefault();
            DelivererIfFull(deliverer);

            _context.SaveChanges();
                       
            return RedirectToAction("ActiveOrders");
        }

        private void DelivererIfFull(Deliverer deliverer)
        {
            List<Order> orders = _context.Orders
                .Where(o => o.DelivererId == deliverer.Id 
                && o.Status == StatusName.VaitingForDelivering 
                || o.Status == StatusName.Active)
                .ToList();
                       
            if(orders.Count -1 == deliverer.Capacity)
            {
                deliverer.IsFull = true;
            }
        }

        public ActionResult AllOrders()
        {
            List<Order> orders = _context.Orders
                                .Include(o => o.Guest)
                                .Include(o => o.Deliverer)
                                .OrderByDescending(o => o.OrderTime)
                                .ToList();
            return View(orders);
        }
    }
}