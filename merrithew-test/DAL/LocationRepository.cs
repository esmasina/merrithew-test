using merrithew_test.Models;
using System.Collections.Generic;
using System.Linq;

namespace merrithew_test.DAL
{
    public class LocationRepository : ILocationRepository/*, IDisposable*/
    {
        private LocationContext context;

        public LocationRepository(LocationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Location> GetLocations()
        {
            using (LocationContext db = new LocationContext())
            {
                return db.Locations.ToList();
            }
        }

        public void InsertLocations(List<Location> locations)
        {
            using (LocationContext db = new LocationContext())
            {
                foreach (Location loc in locations)
                {
                    db.Locations.Add(loc);
                }
            }
        }

        //public void Save()
        //{
        //    context.SaveChanges();
        //}

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}