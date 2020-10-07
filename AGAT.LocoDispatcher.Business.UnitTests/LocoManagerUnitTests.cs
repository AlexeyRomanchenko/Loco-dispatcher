using System;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.Business.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGAT.LocoDispatcher.Business.UnitTests
{
    [TestClass]
    public class LocoManagerUnitTests
    {
        private LocoManager locoManager;
        public LocoManagerUnitTests()
        {
            locoManager = new LocoManager();
        }
        [DataTestMethod]
        [DataRow("14043", 484)]
        public async Task GetActiveByStationAsyncOK(string stationCode, int parkId)
        {
            var locomotives = await locoManager.GetActiveByStationAsync(stationCode, parkId);
            Assert.IsNotNull(locomotives);
        }
    }
}
