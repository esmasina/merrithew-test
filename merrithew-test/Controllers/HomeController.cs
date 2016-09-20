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
        private string filepath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/locations.csv");
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            using (TextFieldParser parser = new TextFieldParser(filepath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool firstLine = true;

                while (!parser.EndOfData)
                {
                    string[] values;
                    try
                    {
                        values = parser.ReadFields();
                        if(firstLine)
                        {
                            //first row (column headings)
                            firstLine = false;
                            continue;
                        }

                    }
                    catch (MalformedLineException ex)
                    {
                        //catch invalid delimited lines
                        continue;
                    }

                    //valid line, construct location object
                    Location loc = new Location();
                    loc.LocationTypeCode = values[0];
                    loc.LocationTypeDesc = values[1];
                    loc.LocationCode = values[2];
                    loc.LocationDesc = values[3];
                    loc.LocationName = values[4];
                    loc.Address = values[5];
                    loc.Phone = values[6];
                    loc.Notes = values[7];
                    loc.Lat = Convert.ToDecimal(values[8]);
                    loc.Long = Convert.ToDecimal(values[9]);
                }
            }
            return View();
        }
    }
}
