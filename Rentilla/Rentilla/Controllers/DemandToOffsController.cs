using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rentilla.Models;

namespace Rentilla.Controllers
{
    public class DemandToOffsController : Controller
    {
        private InterchangeDBContext db = new InterchangeDBContext();

        // GET: DemandToOffs
        public ActionResult Index()
        {
            return View(db.DemandsToOffers.ToList());
        }

        // GET: DemandToOffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandToOff demandToOff = db.DemandsToOffers.Find(id);
            if (demandToOff == null)
            {
                return HttpNotFound();
            }
            return View(demandToOff);
        }

        // GET: DemandToOffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DemandToOffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UID,Titel,Description,Allowance,AllowanceDescription")] DemandToOff demandToOff)
        {
            if (ModelState.IsValid)
            {
                db.DemandsToOffers.Add(demandToOff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demandToOff);
        }

        // GET: DemandToOffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandToOff demandToOff = db.DemandsToOffers.Find(id);
            if (demandToOff == null)
            {
                return HttpNotFound();
            }
            return View(demandToOff);
        }

        // POST: DemandToOffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UID,Titel,Description,Allowance,AllowanceDescription")] DemandToOff demandToOff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demandToOff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demandToOff);
        }

        // GET: DemandToOffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandToOff demandToOff = db.DemandsToOffers.Find(id);
            if (demandToOff == null)
            {
                return HttpNotFound();
            }
            return View(demandToOff);
        }

        // POST: DemandToOffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemandToOff demandToOff = db.DemandsToOffers.Find(id);
            db.DemandsToOffers.Remove(demandToOff);
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
