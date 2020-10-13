using System;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.AuthDB.Models;
using AGAT.LocoDispatcher.AuthDB.Repositories;
using AGAT.LocoDispatcher.AuthDB.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGAT.LocoDispatcher.AuthDB.UnitTests
{
    [TestClass]
    public class UserRepositoryUnitTests
    {
        private UserRepository repository;
        public UserRepositoryUnitTests()
        {
            repository = new UserRepository();
        }
        [DataTestMethod]
        [DataRow("Alex", "010101")]
        public async Task CreateUserOk(string username,string password)
        {
            try
            {
                User user = new User
                {
                    Username = username,
                    Password = HashProducer.HashPassword(password)
                };
                repository.Create(user);
                await repository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        [DataTestMethod]
        [DataRow("Alex", "010101")]
        public async Task GetUserOk(string username, string password)
        {
            try
            {
                User user = new User
                {
                    Username = username,
                    Password = password
                };
                User loggerUser = await repository.GetAsync(user);
                Assert.IsNotNull(loggerUser);
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
