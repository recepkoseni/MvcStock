using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Views
{
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {

            MvcDbStoreEntities db = new MvcDbStoreEntities();
            var degerler = db.TblSales.ToList();
            return View(degerler);
        }
    }
}