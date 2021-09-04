using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AWPABD.Models;

namespace AWPABD.Controllers
{
    public class DatabaseGroupsController : Controller
    {
        private AWPABDEntities db = new AWPABDEntities();

        // GET: DatabaseGroups
        public ActionResult Index()
        {
            return View(db.DatabaseGroup.ToList());
        }

        // GET: DatabaseGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatabaseGroup databaseGroup = db.DatabaseGroup.Find(id);
            if (databaseGroup == null)
            {
                return HttpNotFound();
            }
            return View(databaseGroup);
        }

        // GET: DatabaseGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatabaseGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Grupa")] DatabaseGroup databaseGroup)
        {
            if (ModelState.IsValid)
            {
                db.DatabaseGroup.Add(databaseGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(databaseGroup);
        }

        // GET: DatabaseGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatabaseGroup databaseGroup = db.DatabaseGroup.Find(id);
            if (databaseGroup == null)
            {
                return HttpNotFound();
            }
            return View(databaseGroup);
        }

        // POST: DatabaseGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Grupa")] DatabaseGroup databaseGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(databaseGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(databaseGroup);
        }

        // GET: DatabaseGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatabaseGroup databaseGroup = db.DatabaseGroup.Find(id);
            if (databaseGroup == null)
            {
                return HttpNotFound();
            }
            return View(databaseGroup);
        }

        // POST: DatabaseGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatabaseGroup databaseGroup = db.DatabaseGroup.Find(id);
            db.DatabaseGroup.Remove(databaseGroup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
