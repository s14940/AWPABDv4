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
    public class ProceduriesController : Controller
    {
        private AWPABDEntities db = new AWPABDEntities();

        // GET: Proceduries
        public ActionResult Index()
        {
            var procedury = db.Procedury.Include(p => p.Servers);
            return View(procedury.ToList());
        }

        // GET: Proceduries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedury procedury = db.Procedury.Find(id);
            if (procedury == null)
            {
                return HttpNotFound();
            }
            return View(procedury);
        }

        // GET: Proceduries/Create
        public ActionResult Create()
        {
            ViewBag.Id_Servers = new SelectList(db.Servers, "Id", "Nazwa");
            return View();
        }

        // POST: Proceduries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Body,Utworzona,Zmodyfikowana,Opis,Id_Servers")] Procedury procedury)
        {
            if (ModelState.IsValid)
            {
                db.Procedury.Add(procedury);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Servers = new SelectList(db.Servers, "Id", "Nazwa", procedury.Id_Servers);
            return View(procedury);
        }

        // GET: Proceduries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedury procedury = db.Procedury.Find(id);
            if (procedury == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Servers = new SelectList(db.Servers, "Id", "Nazwa", procedury.Id_Servers);
            return View(procedury);
        }

        // POST: Proceduries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Body,Utworzona,Zmodyfikowana,Opis,Id_Servers")] Procedury procedury)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedury).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Servers = new SelectList(db.Servers, "Id", "Nazwa", procedury.Id_Servers);
            return View(procedury);
        }

        // GET: Proceduries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedury procedury = db.Procedury.Find(id);
            if (procedury == null)
            {
                return HttpNotFound();
            }
            return View(procedury);
        }

        // POST: Proceduries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procedury procedury = db.Procedury.Find(id);
            db.Procedury.Remove(procedury);
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
