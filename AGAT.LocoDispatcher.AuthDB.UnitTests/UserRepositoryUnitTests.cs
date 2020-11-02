﻿using System;
using System.Data.Entity;
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
        private HashProducer hasher;
        public UserRepositoryUnitTests()
        {
            repository = new UserRepository();
            hasher = new HashProducer();
        }
        [DataTestMethod]
        [DataRow("TestUser", "010101")]
        public async Task CreateUserOk(string username,string password)
        {
            try
            {
                User user = new User
                {
                    Username = username + ((int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString(),
                    Password = HashProducer.HashPassword(password),
                    RoleId = 1
                };
                repository.Create(user);
                await repository.SaveAsync();
                
            }
            catch (Exception ex)
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

        [DataTestMethod]
        [DataRow("Test", "Test")]
        public async Task CreateAndRemoveUserOk(string username, string password)
        {
            try
            {
                User user = new User
                {
                    Username = username,
                    Password = HashProducer.HashPassword(password),
                    RoleId = 2
                };
                repository.Create(user);
                await repository.SaveAsync();
                var userToDelete = await repository.GetByIdAsync(user.Id);
                repository.Remove(userToDelete);
                await repository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}