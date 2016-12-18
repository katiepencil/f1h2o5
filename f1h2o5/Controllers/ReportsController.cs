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

        // GET: reports
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: report of drivers with the years they have raced.
        public ActionResult DriversWithYearsRaced()
        {
            var drivers = db.Drivers;
            return View(drivers.ToList());
        }
    }
}