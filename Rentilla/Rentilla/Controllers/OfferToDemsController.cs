﻿using System;
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
    public class OfferToDemsController : Controller
    {
        private InterchangeDBContext db = new InterchangeDBContext();
        private int demandId;
        // GET: OfferToDems
        public ActionResult Index(int demandId)
        {
            this.demandId = demandId;
            return View(db.OffersToDemands.ToList());
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfferToDems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UID,Titel,Description,Allowance,AllowanceDescription")] OfferToDem offerToDem)
        {
            
            if (ModelState.IsValid)
            {
                db.OffersToDemands.Add(offerToDem);
                db.SaveChanges();
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
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
