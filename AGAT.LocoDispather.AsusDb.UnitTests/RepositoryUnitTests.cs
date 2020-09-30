using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.AsusDb.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGAT.LocoDispather.AsusDb.UnitTests
{
    [TestClass]
    public class RepositoryUnitTests
    {
        [TestMethod]
        public async Task GetStationParkOk()
        {
            StationParkRepository repository = new StationParkRepository();
            var station = await repository.GetParkByStationAndCodeAsync("14043", "01");
        }

        [TestMethod]
        public void Test()
        {
            int[] arr = new [] { 34, 54, 4, 65, 354 };
   
        }

        //[TestMethod]
        //public async Task GetTrainsOk()
        //{
        //    TrainRepository repository = new TrainRepository();
        //    List<int> wayIdList = new List<int>
        //    {
        //       23,1917, 2016
        //    };
        //    var trains = await repository.GetTrainsInfoByWayIdsAsync(wayIdList);
        //    Assert.IsNotNull(trains);
        //}
    }
}
