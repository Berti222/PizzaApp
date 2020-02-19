using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    public class PizzasController : Controller
    {
        public PizzaAppContext _context;

        public PizzasController()
        {
            this._context = new PizzaAppContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        // GET: Pizzas
        public ActionResult Index()
        {
            List<Pizza> pizzas = _context.Pizzas.ToList();
            return View(pizzas);
        }

    }
}