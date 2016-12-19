using f1h2o5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace f1h2o5.Controllers
{
    public class ReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // PUT THE LINQ QUERIES HERE for steve's reports.
        // I have not figured out how to use a LINQ query. !!!

        // GET: reports
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        // GET:All drivers who raced in a given year.
        // This is not working yet.
        [Authorize(Roles = "Admin")]
        public ActionResult AllDriversForYearX(string RaceYear)
        {
            var yearModel = from d in db.DriverRunsRaces.Include("Race")
                            select d.Race.RaceYear;
            return View(yearModel);
        }

        // GET:All race results for a given driver.
        // ok, start by drivers with first name starting with letter 'p'!
        // logic not correct yet (I seem to be asking for a boolean result)
        // but LINQ is working!
        [Authorize(Roles = "Admin")]
        public ActionResult AllRaceResultsForDriverX()
        {
            var result = from d in db.Drivers
            select d.FirstName.StartsWith("P");
            return View(result);
        }

        // GET:All race results for a given driver.
        [Authorize(Roles = "Admin")]
        public ActionResult AllTeamsForYearX()
        {

            return View();
        }
    }
}