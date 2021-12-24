using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStoreEntities db = new MvcDbStoreEntities();

        public ActionResult Index()
        {
            var values = db.TblProducts.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> degerler = (from i in db.TblCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.categoryName,
                                                 Value = i.categoryId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(TblProduct p1)
        {
            var ctgr = db.TblCategories.Where(m => m.categoryId == p1.TblCategory.categoryId).FirstOrDefault();
            p1.TblCategory = ctgr;


            db.TblProducts.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var urun = db.TblProducts.Find(id);
            db.TblProducts.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GettoProduct(int id)
        {
            var product = db.TblProducts.Find(id);
            List<SelectListItem> degerler = (from i in db.TblCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.categoryName,
                                                 Value = i.categoryId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("GettoProduct", product);

        }

        public ActionResult Update(TblProduct p)
        {
             var product = db.TblProducts.Find(p.productId);     
            product.productName = p.productName;
            product.brand = p.brand;
            product.stock = p.stock;
            product.price = p.price;
            // product.productCategory = p.productCategory;

            var ctgr = db.TblCategories.Where(m => m.categoryId == p.TblCategory.categoryId).FirstOrDefault();
            product.productCategory = ctgr.categoryId;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}