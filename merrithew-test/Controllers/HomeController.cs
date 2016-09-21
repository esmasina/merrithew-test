using merrithew_test.DAL;
using merrithew_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace merrithew_test.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
                     
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
    }
}
