using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGAT.LocoDispatcher.AuthDB.Utils;
using AGAT.LocoDispatcher.AuthDB.Repositories;
using System.Threading.Tasks;
using System;
using AGAT.LocoDispatcher.AuthDB.Models;

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
        [DataRow("010101")]
        public async Task CompareUserPswdHashOk(string password)
        {
            try
            {
                User usr = new User
                {
                Username = "Alex"
                };
                var repository = new UserRepository();
                var user = await repository.GetAsync(usr);
                bool isEqual = producer.Compare(password, user.Password);
                Assert.IsTrue(isEqual);
            }
            catch (Exception ex)
            {
                throw;
            }

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
