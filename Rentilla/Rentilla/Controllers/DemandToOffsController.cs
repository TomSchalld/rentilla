using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rentilla.Models;
using Microsoft.AspNet.Identity;

namespace Rentilla.Controllers
{
    public class DemandToOffsController : Controller
    {
        private InterchangeDBContext db = new InterchangeDBContext();
        private ApplicationDbContext adbc = new ApplicationDbContext();
        // GET: DemandToOffs
        public ActionResult Index(int? id)
        {
           
            var demandsToOffers = from m in db.DemandsToOffers
                                  select m;
            
            if (id != null)
            {
                var offer = (from d in db.Offers where d.ID == id select d).FirstOrDefault();
                var uname = (from u in adbc.Users where u.Id.Contains(offer.UID) select u).FirstOrDefault();

                ViewBag.Offer = offer;
                ViewBag.Username = uname.UserName;
                demandsToOffers = demandsToOffers.Where(s => s.OfferId == id);
                foreach (var item in demandsToOffers)
                {
                    item.UID = (from u in adbc.Users where u.Id.Contains(item.UID) select u.UserName).FirstOrDefault();
                }
                
                ViewBag.OfferId = id;
            }
            return View(demandsToOffers);
            //return View(db.DemandsToOffers.ToList());
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
        public ActionResult Create(int? id)
        {
            return View();
        }

        // POST: DemandToOffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titel,Description,Allowance,AllowanceDescription")] DemandToOff demandToOff, int? id)
        {
            if (id != null)
            {
                demandToOff.OfferId = (int)id;

            }
            demandToOff.UID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.DemandsToOffers.Add(demandToOff);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = demandToOff.OfferId });
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
                return RedirectToAction("Index", new { id = demandToOff.OfferId });
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
            return RedirectToAction("Index", new { id = demandToOff.OfferId });
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
