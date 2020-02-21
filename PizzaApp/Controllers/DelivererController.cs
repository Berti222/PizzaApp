using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.Controllers
{
    public class DelivererController : Controller
    {
        public PizzaAppContext _context;

        public DelivererController()
        {
            this._context = new PizzaAppContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
        // GET: Deliverer
        public ActionResult Index()
        {
            List<Deliverer> deliverers = _context.Deliverers.ToList();
            return View(deliverers);
        }

        public ActionResult Send(int id)
        {
            Deliverer delivererInDB = _context.Deliverers.Where(x => x.Id == id).SingleOrDefault();

            List<Order> orders = _context
                    .Orders
                    .Where(o => o.Status == StatusName.VaitingForDelivering
                    || o.Status == StatusName.Active)                    
                    .ToList();

            if (delivererInDB.IsOnWay == false)
            {
                foreach (Order order in orders)
                {
                    if(order.Status == StatusName.VaitingForDelivering && order.DelivererId == delivererInDB.Id)
                    {
                        order.Status = StatusName.Active;
                    }
                }
                delivererInDB.IsOnWay = true;
            }
            else
            {
                foreach (Order order in orders)
                {
                    if (order.Status == StatusName.Active && order.DelivererId == delivererInDB.Id)
                    {
                        order.Status = StatusName.Delivered;
                    }
                }
                if(delivererInDB.IsFull == true)                
                    delivererInDB.IsFull = false;
                
                delivererInDB.IsOnWay = false;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}