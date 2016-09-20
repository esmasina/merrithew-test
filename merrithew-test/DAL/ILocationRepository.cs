using merrithew_test.Models;
using System;
using System.Collections.Generic;


namespace merrithew_test.DAL
{
    public interface ILocationRepository /*: IDisposable*/
    {
        IEnumerable<Location> GetLocations();
        void InsertLocations(List<Location> locations);
        //void Save();
    }
}