using merrithew_test.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace merrithew_test.Controllers
{
    public class HomeController : Controller
    {
        private LocationContext db = new LocationContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(db.Locations.ToList());
        }
    }
}
