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
    public class OfferToDemsController : Controller
    {
        private InterchangeDBContext db = new InterchangeDBContext();
        private ApplicationDbContext adbc = new ApplicationDbContext();

        // GET: OfferToDems
        public ActionResult Index(int? id)
        {
            
            var offersTodemands = from m in db.OffersToDemands
                         select m;
            if (id != null)
            {
                var demand = (from d in db.Demands where d.ID == id select d).FirstOrDefault();
                var uname = (from u in adbc.Users where u.Id.Contains(demand.UID) select u).FirstOrDefault();

                
                ViewBag.Username = uname.UserName;
                offersTodemands = offersTodemands.Where(s => s.DemandId == id);
                foreach (var item in offersTodemands)
                {
                    item.UID = (from u in adbc.Users where u.Id.Contains(item.UID) select u.UserName).FirstOrDefault();
                }
                ViewBag.Demand = demand;
                ViewBag.DemandId = id;
            }
            return View(offersTodemands);
            //return View(db.OffersToDemands.ToList());
        }

        // GET: OfferToDems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferToDem offerToDem = db.OffersToDemands.Find(id);
            if (offerToDem == null)
            {
                return HttpNotFound();
            }
            return View(offerToDem);
        }

        // GET: OfferToDems/Create
        public ActionResult Create(int? id)
        {
            
            return View();
        }

        // POST: OfferToDems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titel,Description,Allowance,AllowanceDescription")] OfferToDem offerToDem, int? id)
        {
            if (id != null)
            {
                offerToDem.DemandId = (int)id;

            }
            offerToDem.UID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.OffersToDemands.Add(offerToDem);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = offerToDem.DemandId });
            }

            return View(offerToDem);
        }

        // GET: OfferToDems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferToDem offerToDem = db.OffersToDemands.Find(id);
            if (offerToDem == null)
            {
                return HttpNotFound();
            }
            return View(offerToDem);
        }

        // POST: OfferToDems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UID,Titel,Description,Allowance,AllowanceDescription")] OfferToDem offerToDem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerToDem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = offerToDem.DemandId });
            }
            return View(offerToDem);
        }

        // GET: OfferToDems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferToDem offerToDem = db.OffersToDemands.Find(id);
            if (offerToDem == null)
            {
                return HttpNotFound();
            }
            return View(offerToDem);
        }

        // POST: OfferToDems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfferToDem offerToDem = db.OffersToDemands.Find(id);
            db.OffersToDemands.Remove(offerToDem);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = offerToDem.DemandId });
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
