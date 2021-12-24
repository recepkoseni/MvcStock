using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;


namespace MvcStock.Controllers
{
    public class CustomerController : Controller
    {
        MvcDbStoreEntities db = new MvcDbStoreEntities();
        // GET: Customer
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TblCustomers select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.customerName.Contains(p));
            }
            return View(degerler.ToList());

            //var degerler = db.TblCustomers.ToList();
            //return View(degerler);
        }
    
        [HttpGet]
        public ActionResult NewCustomer()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(TblCustomer p1)

        {
            MvcDbStoreEntities db = new MvcDbStoreEntities();
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            
            db.TblCustomers.Add(p1);
            db.SaveChanges();
            return View();  
        }

        public ActionResult Delete(int id)
        {
            MvcDbStoreEntities db = new MvcDbStoreEntities();
            var customer = db.TblCustomers.Find(id);
            db.TblCustomers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GettoCustomer(int id)
        {
            var cus = db.TblCustomers.Find(id);
            return View("GettoCustomer", cus);
        }

        public ActionResult Update(TblCustomer p1)
        {
            var cus = db.TblCustomers.Find(p1.customerId);
            cus.customerName = p1.customerName;
            cus.customerSurname = p1.customerSurname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}