using merrithew_test.Models;
using System;
using System.Collections.Generic;


namespace merrithew_test.DAL
{
    public interface ILocationRepository : IDisposable
    {
        IEnumerable<Location> GetLocations(string lat, string lng, string radius);
        bool InsertLocations(List<Location> locations);
        void Save();
    }
}