using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public MvcDbStoreEntities db = new MvcDbStoreEntities();

        public ActionResult Index(int page=1)
        {
            // var values = db.TblCategories.ToList();
            var values = db.TblCategories.ToList().ToPagedList(page, 4);


            return View(values);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]

        public ActionResult NewCategory(TblCategory p1)
        {

            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.TblCategories.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var ktgr = db.TblCategories.Find(id);
            db.TblCategories.Remove(ktgr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GettoCategories(int id)
        {
            var ctgr = db.TblCategories.Find(id);
            return View("GettoCategories", ctgr);

        }

        public ActionResult Update(TblCategory p1)
        {
            var ctgr = db.TblCategories.Find(p1.categoryId);
            ctgr.categoryName = p1.categoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}