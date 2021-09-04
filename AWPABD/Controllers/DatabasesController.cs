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
    public class DatabasesController : Controller
    {
        private AWPABDEntities db = new AWPABDEntities();

        // GET: Databases
        public ActionResult Index()
        {
            var databases = db.Databases.Include(d => d.DatabaseGroup).Include(d => d.Servers);
            return View(databases.ToList());
        }

        // GET: Databases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Databases databases = db.Databases.Find(id);
            if (databases == null)
            {
                return HttpNotFound();
            }
            return View(databases);
        }

        // GET: Databases/Create
        public ActionResult Create()
        {
            ViewBag.Id_DatabaseGroup = new SelectList(db.DatabaseGroup, "Id", "Nazwa");
            ViewBag.Id_Servers = new SelectList(db.Servers, "Id", "Nazwa");
            return View();
        }

        // POST: Databases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Opis,Wlaczona,Owner,Collation,Type,Status,Id_DatabaseGroup,Id_Servers")] Databases databases)
        {
            if (ModelState.IsValid)
            {
                db.Databases.Add(databases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_DatabaseGroup = new SelectList(db.DatabaseGroup, "Id", "Nazwa", databases.Id_DatabaseGroup);
            ViewBag.Id_Servers = new SelectList(db.Servers, "Id", "Nazwa", databases.Id_Servers);
            return View(databases);
        }

        // GET: Databases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Databases databases = db.Databases.Find(id);
            if (databases == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_DatabaseGroup = new SelectList(db.DatabaseGroup, "Id", "Nazwa", databases.Id_DatabaseGroup);
            ViewBag.Id_Servers = new SelectList(db.Servers, "Id", "Nazwa", databases.Id_Servers);
            return View(databases);
        }

        // POST: Databases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Opis,Wlaczona,Owner,Collation,Type,Status,Id_DatabaseGroup,Id_Servers")] Databases databases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(databases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_DatabaseGroup = new SelectList(db.DatabaseGroup, "Id", "Nazwa", databases.Id_DatabaseGroup);
            ViewBag.Id_Servers = new SelectList(db.Servers, "Id", "Nazwa", databases.Id_Servers);
            return View(databases);
        }

        // GET: Databases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Databases databases = db.Databases.Find(id);
            if (databases == null)
            {
                return HttpNotFound();
            }
            return View(databases);
        }

        // POST: Databases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Databases databases = db.Databases.Find(id);
            db.Databases.Remove(databases);
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
