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
        
        // ok, start by first name of all drivers!
         [Authorize(Roles = "Admin")]
        public ActionResult FirstNamesOfDrivers()
        {
            var result = from d in db.Drivers
                         select d.FirstName.ToString();
            return View(result);
        }

        // GET:All race results for a given driver.
        // logic not correct yet (I seem to be asking for a boolean result)
        // but LINQ is working!
        [Authorize(Roles = "Admin")]
        public ActionResult AllRaceResultsForDriverX()
        {
            var result = from d in db.Drivers
            select d.LastName.ToString();
            return View(result);
        } 
        
        // GET:All drivers who raced in a given year.
        // This is not working yet.
        [Authorize(Roles = "Admin")]
        public ActionResult AllDriversForYearX()
        {
            var result = from d in db.Teams
                         select d.Name.ToString();
            return View(result);
        }

        // GET:All race results for a given driver.
        [Authorize(Roles = "Admin")]
        public ActionResult AllTeamsForYearX()
        {
            var result = from d in db.Drivers
                         select d.City.ToString();
            return View(result);
        }
    }
}