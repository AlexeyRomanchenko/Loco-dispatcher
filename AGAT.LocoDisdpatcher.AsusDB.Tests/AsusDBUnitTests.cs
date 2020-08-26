using AGAT.LocoDispatcher.AsusDb.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AGAT.LocoDisdpatcher.AsusDB.Tests
{
    public class AsusDBUnitTests
    {
        [Theory]
        [InlineData("14043", "02")]
        public async Task GetStationParkOK(string station, string code)
        {
            StationParkRepository repository = new StationParkRepository();
            var _station =  await repository.GetParkByStationAndCodeAsync(station, code);
            Assert.NotNull(_station);
        }
    }
}
