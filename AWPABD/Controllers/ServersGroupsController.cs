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
    public class ServersGroupsController : Controller
    {
        private AWPABDEntities db = new AWPABDEntities();

        // GET: ServersGroups
        public ActionResult Index()
        {
            return View(db.ServersGroup.ToList());
        }

        // GET: ServersGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServersGroup serversGroup = db.ServersGroup.Find(id);
            if (serversGroup == null)
            {
                return HttpNotFound();
            }
            return View(serversGroup);
        }

        // GET: ServersGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServersGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Grupa")] ServersGroup serversGroup)
        {
            if (ModelState.IsValid)
            {
                db.ServersGroup.Add(serversGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serversGroup);
        }

        // GET: ServersGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServersGroup serversGroup = db.ServersGroup.Find(id);
            if (serversGroup == null)
            {
                return HttpNotFound();
            }
            return View(serversGroup);
        }

        // POST: ServersGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Grupa")] ServersGroup serversGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serversGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serversGroup);
        }

        // GET: ServersGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServersGroup serversGroup = db.ServersGroup.Find(id);
            if (serversGroup == null)
            {
                return HttpNotFound();
            }
            return View(serversGroup);
        }

        // POST: ServersGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServersGroup serversGroup = db.ServersGroup.Find(id);
            db.ServersGroup.Remove(serversGroup);
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
