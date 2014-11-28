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
    public class SystemUserController : BaseController
    {
        private SampleContext db = new SampleContext();

        //
        // GET: /SystemUser/

        public ActionResult Index()
        {
            return View(db.SystemUsers.ToList());
        }

        //
        // GET: /SystemUser/Details/5

        public ActionResult Details(Guid id)
        {
            SystemUser systemuser = db.SystemUsers.Include(su => su.SystemRoles).FirstOrDefault(su => su.ID == id);
            if (systemuser == null)
            {
                return HttpNotFound();
            }
            return View(systemuser);
        }

        //
        // GET: /SystemUser/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SystemUser/Create

        [HttpPost]
        public ActionResult Create(SystemUser systemuser)
        {
            if (ModelState.IsValid)
            {
                systemuser.ID = Guid.NewGuid();
                db.SystemUsers.Add(systemuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(systemuser);
        }

        //
        // GET: /SystemUser/Edit/5

        public ActionResult Edit(Guid id)
        {
            //SystemUser systemuser = db.SystemUsers.Find(id);
            SystemUser systemuser = db.SystemUsers.Include(x => x.SystemRoles).FirstOrDefault(x => x.ID == id);
            if (systemuser == null)
            {
                return HttpNotFound();
            }

            ViewBag.SelectList = SystemRole.Instance.getActiveSystemRolesForSelectList(systemuser);

            return View(systemuser);
        }

        //
        // POST: /SystemUser/Edit/5

        [HttpPost]
        public ActionResult Edit(SystemUser systemuser, Guid[] roles)
        {
            if (ModelState.IsValid)
            {
                SystemUser SystemUserObj = db.SystemUsers.Include(su => su.SystemRoles).FirstOrDefault(su => su.ID == systemuser.ID);
                SystemUserObj.IsEnable = systemuser.IsEnable;
                SystemUserObj.Name = systemuser.Name;
                SystemUserObj.Password = systemuser.Password;
                SystemUserObj.UpdateOn = DateTime.Now;
                this.UpdateSystemRoleRelation(SystemUserObj, roles);
                db.Entry(SystemUserObj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SelectList = SystemRole.Instance.getActiveSystemRolesForSelectList(systemuser);
            return View(systemuser);
        }

        public void UpdateSystemRoleRelation(SystemUser SystemUserObj, Guid[] roles)
        {
            if (roles == null)
            {
                SystemUserObj.SystemRoles = new List<SystemRole>();
                return;
            }
            var currentRolesID = SystemUserObj.SystemRoles.Select(sr => sr.ID);
            foreach (SystemRole Role in db.SystemRoles)
            {
                if (roles.Contains(Role.ID))
                {
                    if(!currentRolesID.Contains(Role.ID))
                    {
                        SystemUserObj.SystemRoles.Add(Role);
                    }
                }
                else
                {
                    if (currentRolesID.Contains(Role.ID))
                    {
                        SystemUserObj.SystemRoles.Remove(Role);
                    }
                }
            }
        }

        //
        // GET: /SystemUser/Delete/5

        public ActionResult Delete(Guid id)
        {
            SystemUser systemuser = db.SystemUsers.Include(su => su.SystemRoles).FirstOrDefault(su => su.ID == id);

            if (systemuser == null)
            {
                return HttpNotFound();
            }

            ViewBag.SystemRoleNames=systemuser.SystemRoles.Count.Equals(0) ? "" : string.Join(",",systemuser.SystemRoles.Select(sr=>sr.Name));

            return View(systemuser);
        }

        //
        // POST: /SystemUser/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SystemUser systemuser = db.SystemUsers.Include(su => su.SystemRoles).FirstOrDefault(su => su.ID == id);
            systemuser.SystemRoles = null;
            db.SystemUsers.Remove(systemuser);
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