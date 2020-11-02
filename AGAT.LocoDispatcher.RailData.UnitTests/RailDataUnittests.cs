using System;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.RailData.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGAT.LocoDispatcher.RailData.UnitTests
{
    [TestClass]
    public class RailDataUnittests
    {
        [DataTestMethod]
        [DataRow("OOP008003007")]
        [DataRow("OOP008003011")]
        public async Task GetInfoByPointCodeOk(string pointCode)
        {
            PointRepository repository = new PointRepository();
            var res = await repository.GetStationInfoByPointCode(pointCode);
            Assert.IsNotNull(res);

        }
    }
}
