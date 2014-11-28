using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Models;

namespace CodeFirst.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private SampleContext db = new SampleContext();

        //
        // GET: /ProductCategory/

        public ActionResult Index()
        {
            return View(db.ProductCategory.ToList());
        }

        //
        // GET: /ProductCategory/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductCategory productcategory = db.ProductCategory.Find(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            return View(productcategory);
        }

        //
        // GET: /ProductCategory/Create

        public ActionResult Create()
        {
            ProductCategory productcategory = new ProductCategory();
            productcategory.buildTranslation();
            return View(productcategory);
        }

        //
        // POST: /ProductCategory/Create

        [HttpPost]
        public ActionResult Create(ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategory.Add(productcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productcategory);
        }

        //
        // GET: /ProductCategory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductCategory productcategory = db.ProductCategory.Find(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            return View(productcategory);
        }

        //
        // POST: /ProductCategory/Edit/5

        [HttpPost]
        public ActionResult Edit(ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productcategory).State = EntityState.Modified;
                foreach (var translation in productcategory.Translations)
                {
                    db.Entry(translation).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productcategory);
        }

        //
        // GET: /ProductCategory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductCategory productcategory = db.ProductCategory.Find(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            return View(productcategory);
        }

        //
        // POST: /ProductCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategory productcategory = db.ProductCategory.Find(id);
            db.ProductCategory.Remove(productcategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}