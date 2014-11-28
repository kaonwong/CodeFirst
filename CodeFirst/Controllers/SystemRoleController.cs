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
    public class SystemRoleController : BaseController
    {
        private SampleContext db = new SampleContext();

        //
        // GET: /SystemRole/

        public ActionResult Index()
        {
            return View(db.SystemRoles.ToList());
        }

        //
        // GET: /SystemRole/Details/5

        public ActionResult Details(Guid id)
        {
            SystemRole systemrole = db.SystemRoles.Find(id);
            if (systemrole == null)
            {
                return HttpNotFound();
            }
            return View(systemrole);
        }

        //
        // GET: /SystemRole/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SystemRole/Create

        [HttpPost]
        public ActionResult Create(SystemRole systemrole)
        {
            if (ModelState.IsValid)
            {
                systemrole.ID = Guid.NewGuid();
                db.SystemRoles.Add(systemrole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(systemrole);
        }

        //
        // GET: /SystemRole/Edit/5

        public ActionResult Edit(Guid id)
        {
            SystemRole systemrole = db.SystemRoles.Find(id);
            if (systemrole == null)
            {
                return HttpNotFound();
            }
            return View(systemrole);
        }

        //
        // POST: /SystemRole/Edit/5

        [HttpPost]
        public ActionResult Edit(SystemRole systemrole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systemrole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systemrole);
        }

        //
        // GET: /SystemRole/Delete/5

        public ActionResult Delete(Guid id)
        {
            SystemRole systemrole = db.SystemRoles.Find(id);
            if (systemrole == null)
            {
                return HttpNotFound();
            }
            return View(systemrole);
        }

        //
        // POST: /SystemRole/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SystemRole systemrole = db.SystemRoles.Find(id);
            db.SystemRoles.Remove(systemrole);
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