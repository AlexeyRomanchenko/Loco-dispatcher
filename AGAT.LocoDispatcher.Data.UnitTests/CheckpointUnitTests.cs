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
            DatabaseContext context = new DatabaseContext();
            repository = new CheckpointEventRepository(context);
        }
        [DataTestMethod]
        [DataRow(70)]
        public async Task GetLastCheckpointEventOk(int shiftId)
        {
            string checkpoint = await repository.GetLastCheckpointByShiftIdAsync(shiftId);
            Assert.IsNotNull(checkpoint);
        }

        [DataTestMethod]
        [DataRow("0014")]
        public async Task GetLastCheckpointEventByTrainIdOk(string trainId)
        {
            string checkpoint = await repository.GetLastCheckpointByLocoIdAsync(trainId);
            Assert.IsNotNull(checkpoint);
        }
    }
}
