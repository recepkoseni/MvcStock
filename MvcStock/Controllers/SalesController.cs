using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        MvcDbStoreEntities db = new MvcDbStoreEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(TblSale p)
        {
            db.TblSales.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}