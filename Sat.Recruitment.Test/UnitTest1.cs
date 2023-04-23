using System;
using System.Dynamic;
using System.IO;
using Business;
using Business.Contracts;
using Data;
using Data.Contracts;
using Data.DataAccess;
using Entities;
using Entities.Definitions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers;

using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            
            var dataContex = new DataContext("\\Files\\Users.txt");
            var userDataAcces = new UserDataAccess(dataContex);
            var userManager = new UserManager(userDataAcces);
            
            var user = new User()
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                Type = "Normal",
                Money = 124
            };
            var userController = new UsersController(userManager);
            
            var result = await userController.CreateUser(user);


            Assert.Equal(true, result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void Test2()
        {
            var dataContex = new DataContext("\\Files\\Users.txt");
            var userDataAcces = new UserDataAccess(dataContex);
            var userManager = new UserManager(userDataAcces);
            var userController = new UsersController(userManager);
            var user = new User()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+534645213542",
                Type = "Normal",
                Money = 124
            };

            var result = userController.CreateUser(user).Result;


            Assert.Equal(false, result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }
    }
}
