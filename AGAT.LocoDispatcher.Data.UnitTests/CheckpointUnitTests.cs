using System;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGAT.LocoDispatcher.Data.UnitTests
{
    [TestClass]
    public class CheckpointUnitTests
    {
        private CheckpointEventRepository repository;
        public CheckpointUnitTests()
        {
            repository = new CheckpointEventRepository();
        }
        [TestMethod]
        public async Task GetLastCheckpointEventOk()
        {
            string trainId = "615";
            string checkpoint = await repository.GetLastCheckpointByTrainIdAsync(trainId);
            Assert.IsNotNull(checkpoint);
        }
    }
}
