using merrithew_test.DAL;
using merrithew_test.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace merrithew_test.Controllers
{
    public class ImportController : Controller
    {
        //private string filepath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/locations.csv");
        private string url = "http://app.toronto.ca/opendata/ac_locations/locations.csv?v=1.00";

        private ILocationRepository _repo;

        public ImportController()
        {
            this._repo = new LocationRepository(new LocationContext());
        }

        // GET:
        public ActionResult Import()
        {
            List<Location> Locations = new List<Location>();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            StreamReader StreamReader = new StreamReader(httpWebResponse.GetResponseStream());

            using (TextFieldParser parser = new TextFieldParser(StreamReader))
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
                        if (firstLine)
                        {
                            //skip first row (column headings)
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

                    Locations.Add(loc);
                }
            }

            bool status = _repo.InsertLocations(Locations);
            if (status == true)
            {
                ViewBag.Message = "Import Successful.";
            }
            else
            {
                ViewBag.Message = "There was a problem with the import.";
            }
                    
            return View();
        }
    }
}