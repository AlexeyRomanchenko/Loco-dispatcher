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
        [DataRow("623")]
        public async Task GetInfoByPointCodeOk(string pointCode)
        {
            PointRepository repository = new PointRepository();
            var res = await repository.GetStationInfoByPointCode(pointCode);
            Assert.IsNotNull(res);

        }
    }
}
