using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using f1h2o5.Models;

namespace f1h2o5.Controllers
{
    public class RaceResultTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RaceResultTypes
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.RaceResultTypes.ToList());
        }

        // GET: RaceResultTypes/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaceResultType raceResultType = db.RaceResultTypes.Find(id);
            if (raceResultType == null)
            {
                return HttpNotFound();
            }
            return View(raceResultType);
        }

        [Authorize(Roles ="Admin")]
        // GET: RaceResultTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RaceResultTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResultTypeId,ResultTypeName")] RaceResultType raceResultType)
        {
            if (ModelState.IsValid)
            {
                db.RaceResultTypes.Add(raceResultType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raceResultType);
        }

        // GET: RaceResultTypes/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaceResultType raceResultType = db.RaceResultTypes.Find(id);
            if (raceResultType == null)
            {
                return HttpNotFound();
            }
            return View(raceResultType);
        }

        // POST: RaceResultTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResultTypeId,ResultTypeName")] RaceResultType raceResultType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raceResultType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raceResultType);
        }

        // GET: RaceResultTypes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaceResultType raceResultType = db.RaceResultTypes.Find(id);
            if (raceResultType == null)
            {
                return HttpNotFound();
            }
            return View(raceResultType);
        }

        // POST: RaceResultTypes/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RaceResultType raceResultType = db.RaceResultTypes.Find(id);
            db.RaceResultTypes.Remove(raceResultType);
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
