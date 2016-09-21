using merrithew_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace merrithew_test.DAL
{
    public class LocationRepository : ILocationRepository, IDisposable
    {
        private LocationContext context;

        public LocationRepository(LocationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Location> GetLocations()
        {
            using (context)
            {
                return context.Locations.ToList();
            }
        }

        public bool InsertLocations(List<Location> locations)
        {
            using (context)
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //truncate table
                        context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Locations]");

                        //insert locations
                        foreach (Location loc in locations)
                        {
                            context.Locations.Add(loc);
                        }

                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}