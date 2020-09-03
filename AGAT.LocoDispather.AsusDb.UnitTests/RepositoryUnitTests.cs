using System;
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
        public async Task GetTrainsOk()
        {
            TrainRepository repository = new TrainRepository();
            var trains = repository.GetTrains();
            Assert.IsNotNull(trains);
        }
    }
}
