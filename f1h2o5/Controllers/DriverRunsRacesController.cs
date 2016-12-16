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
    public class DriverRunsRacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DriverRunsRaces
        public ActionResult Index()
        {
            var driverRunsRaces = db.DriverRunsRaces.Include(d => d.Driver).Include(d => d.Race).Include(d => d.RaceResultType);
            return View(driverRunsRaces.ToList());
        }

        // GET: DriverRunsRaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverRunsRace driverRunsRace = db.DriverRunsRaces.Find(id);
            if (driverRunsRace == null)
            {
                return HttpNotFound();
            }
            return View(driverRunsRace);
        }

        // GET: DriverRunsRaces/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "FirstName");
            ViewBag.RaceId = new SelectList(db.Races, "RaceId", "RaceName");
            ViewBag.ResultTypeId = new SelectList(db.RaceResultTypes, "ResultTypeId", "ResultTypeName");
            return View();
        }

        // POST: DriverRunsRaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverId,RaceId,ResultTypeId,RaceTime")] DriverRunsRace driverRunsRace)
        {
            if (ModelState.IsValid)
            {
                db.DriverRunsRaces.Add(driverRunsRace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "FirstName", driverRunsRace.DriverId);
            ViewBag.RaceId = new SelectList(db.Races, "RaceId", "RaceName", driverRunsRace.RaceId);
            ViewBag.ResultTypeId = new SelectList(db.RaceResultTypes, "ResultTypeId", "ResultTypeName", driverRunsRace.ResultTypeId);
            return View(driverRunsRace);
        }

        // GET: DriverRunsRaces/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverRunsRace driverRunsRace = db.DriverRunsRaces.Find(id);
            if (driverRunsRace == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "FirstName", driverRunsRace.DriverId);
            ViewBag.RaceId = new SelectList(db.Races, "RaceId", "RaceName", driverRunsRace.RaceId);
            ViewBag.ResultTypeId = new SelectList(db.RaceResultTypes, "ResultTypeId", "ResultTypeName", driverRunsRace.ResultTypeId);
            return View(driverRunsRace);
        }

        // POST: DriverRunsRaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverId,RaceId,ResultTypeId,RaceTime")] DriverRunsRace driverRunsRace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverRunsRace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "FirstName", driverRunsRace.DriverId);
            ViewBag.RaceId = new SelectList(db.Races, "RaceId", "RaceName", driverRunsRace.RaceId);
            ViewBag.ResultTypeId = new SelectList(db.RaceResultTypes, "ResultTypeId", "ResultTypeName", driverRunsRace.ResultTypeId);
            return View(driverRunsRace);
        }

        // GET: DriverRunsRaces/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverRunsRace driverRunsRace = db.DriverRunsRaces.Find(id);
            if (driverRunsRace == null)
            {
                return HttpNotFound();
            }
            return View(driverRunsRace);
        }

        // POST: DriverRunsRaces/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriverRunsRace driverRunsRace = db.DriverRunsRaces.Find(id);
            db.DriverRunsRaces.Remove(driverRunsRace);
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
