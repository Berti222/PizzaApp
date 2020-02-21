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

            return View();
        }
    }
}