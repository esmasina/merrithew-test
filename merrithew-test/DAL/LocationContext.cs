using merrithew_test.Models;
using System.Data.Entity;


namespace merrithew_test.DAL
{
    public class LocationContext : DbContext
    {
        public LocationContext() : base("LocationContext")
        { }

        public DbSet<Location> Locations { get; set; }
    }
}