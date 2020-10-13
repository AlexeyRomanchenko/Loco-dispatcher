using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGAT.LocoDispatcher.AuthDB.Utils;

namespace AGAT.LocoDispatcher.AuthDB.UnitTests
{
    [TestClass]
    public class PasswordHasherUnitTests
    {
        private HashProducer producer;
        public PasswordHasherUnitTests()
        {
            producer = new HashProducer();
        }
        [DataTestMethod]
        [DataRow("password")]
        public void PasswordHashReturnsOk(string password)
        {
            string hash = HashProducer.HashPassword(password);
            Assert.IsNotNull(hash);
        }
    }
}
