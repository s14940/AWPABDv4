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
    public class LatenciesController : Controller
    {
        private AWPABDEntities db = new AWPABDEntities();

        // GET: Latencies
        public ActionResult Index()
        {
            var latency = db.Latency.Include(l => l.Servers).Include(l => l.Servers1);
            return View(latency.ToList());
        }

        // GET: Latencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Latency latency = db.Latency.Find(id);
            if (latency == null)
            {
                return HttpNotFound();
            }
            return View(latency);
        }

        // GET: Latencies/Create
        public ActionResult Create()
        {
            ViewBag.Id_ServersD = new SelectList(db.Servers, "Id", "Nazwa");
            ViewBag.Id_ServersS = new SelectList(db.Servers, "Id", "Nazwa");
            return View();
        }

        // POST: Latencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Id_ServersS,Id_ServersD,Opis,Typ")] Latency latency)
        {
            if (ModelState.IsValid)
            {
                db.Latency.Add(latency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_ServersD = new SelectList(db.Servers, "Id", "Nazwa", latency.Id_ServersD);
            ViewBag.Id_ServersS = new SelectList(db.Servers, "Id", "Nazwa", latency.Id_ServersS);
            return View(latency);
        }

        // GET: Latencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Latency latency = db.Latency.Find(id);
            if (latency == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_ServersD = new SelectList(db.Servers, "Id", "Nazwa", latency.Id_ServersD);
            ViewBag.Id_ServersS = new SelectList(db.Servers, "Id", "Nazwa", latency.Id_ServersS);
            return View(latency);
        }

        // POST: Latencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Id_ServersS,Id_ServersD,Opis,Typ")] Latency latency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(latency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_ServersD = new SelectList(db.Servers, "Id", "Nazwa", latency.Id_ServersD);
            ViewBag.Id_ServersS = new SelectList(db.Servers, "Id", "Nazwa", latency.Id_ServersS);
            return View(latency);
        }

        // GET: Latencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Latency latency = db.Latency.Find(id);
            if (latency == null)
            {
                return HttpNotFound();
            }
            return View(latency);
        }

        // POST: Latencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Latency latency = db.Latency.Find(id);
            db.Latency.Remove(latency);
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
