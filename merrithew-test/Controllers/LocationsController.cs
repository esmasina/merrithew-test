using merrithew_test.DAL;
using merrithew_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace merrithew_test.Controllers
{
    public class LocationsController : ApiController
    {
        private ILocationRepository _repo;

        public LocationsController()
        {
            this._repo = new LocationRepository(new LocationContext());
        }
        // GET: api/Locations
        public IEnumerable<Location> Get()
        {
            return _repo.GetLocations();
        }

    }
}
