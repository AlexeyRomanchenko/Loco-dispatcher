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

        [DataTestMethod]
        [DataRow("Password")]
        public void ComparePswdHashOk(string password)
        {
            string hash = HashProducer.HashPassword(password);
            var isEqual = producer.Compare(password, hash);
            Assert.IsTrue(isEqual);
        }

        [DataTestMethod]
        [DataRow("Password","Password2")]
        public void ComparePswdHashFailed(string password, string wrongPassword)
        {
            string hash = HashProducer.HashPassword(password);
            bool isEqual = producer.Compare(wrongPassword, hash);
            Assert.IsFalse(isEqual);
        }

    }
}
