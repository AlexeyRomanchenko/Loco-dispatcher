using System;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGAT.LocoDispatcher.Data.UnitTests
{
    [TestClass]
    public class LocoUnitTests
    {
        private ShiftRepository repository;
        public LocoUnitTests()
        {
            DatabaseContext context = new DatabaseContext();
            repository = new ShiftRepository();
        }
        [DataTestMethod]
        [DataRow("14043")]
        public async Task GetLoomotiveWithLastEventOK(string station)
        {
            await repository.GetActiveLocomotivesWithLastEventsAsync(station);
            //Assert.IsNotNull(checkpoint);
        }

        [DataTestMethod]
        [DataRow("14043")]
        public async Task GetActiveLocomotivesOK(string station)
        {
            var locos = await repository.GetActiveByStationAsync(station);
            Assert.IsNotNull(locos);
        }
    }
}
