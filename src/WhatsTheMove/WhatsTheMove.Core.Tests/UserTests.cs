using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTheMove.Core.API;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.Tests
{
    [TestClass]
    public class UserTests
    {
        private static User TestUser = new User()
        {
            Username = "testuser",
            Email = "testuser@testuser.com",
            FirstName = "Test",
            LastName = "User",
            DateOfBirth = new System.DateTime(year: 1999, month: 1, day: 25),
            ZipCode = "45245",
            Password = "a6e5rg14a6r5g16awe85r1g6r8gb",
            PasswordConfirmed = "a6e5rg14a6r5g16awe85r1g6r8gb",
            HashKey = "a6e5rg14a6r5g16awe85r1g6r8gb",
            ForgotPasswordKey = null,
            IsDarkModePreferred = true,
            DateAdded = System.DateTime.Now
        };

        [TestMethod]
        public async Task A_CreateUserTest()
        {
            // Initialize api helper
            ApiHelper.InitializeClient();

            // Create
            User user = await UserProcessor.CreateUser(TestUser);

            Assert.IsNotNull(user);
        }


        [TestMethod]
        public async Task B_GetUsersTest()
        {
            // Initialize api helper
            ApiHelper.InitializeClient();

            IEnumerable<User> users = await UserProcessor.LoadUsers();

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Any());
        }


        [TestMethod]
        public async Task C_GetUserTest()
        {
            await GetCreateUser();

            User user1 = await UserProcessor.LoadUser(TestUser.Username);

            Assert.IsNotNull(user1);

            User user2 = await UserProcessor.LoadUser(user1.Id);

            Assert.IsNotNull(user2);

            Assert.IsTrue(user1.Equals(user2));
        }


        [TestMethod]
        public async Task D_UpdateUserTest()
        {
            User user1 = await GetCreateUser();

            Assert.IsNotNull(user1);

            // Update
            User user2 = new User()
            {
                Id = user1.Id,
                Username = "testuser",
                Email = "testuser@testuser.com",
                FirstName = "Test1",
                LastName = "User1",
                DateOfBirth = new System.DateTime(year: 1990, month: 1, day: 25),
                ZipCode = "45219",
                Password = "qoa[igjhoqaerwihjgoiqewrjhnboiqaerjg",
                PasswordConfirmed = "qaigjhaoewlirkhjoiewrjhg",
                HashKey = "qrl[igjaoewirgjoerigjneroi",
                ForgotPasswordKey = null,
                IsDarkModePreferred = false,
                DateAdded = System.DateTime.Now
            };

            user2 = await UserProcessor.UpdateUser(user2);

            Assert.IsNotNull(user2);
            Assert.IsFalse(user1.Equals(user2));
            Assert.AreEqual(user2.FirstName, "Test1");
        }


        [TestMethod]
        public async Task E_DeleteUser()
        {
            await GetCreateUser();

            User user1 = await UserProcessor.LoadUser(TestUser.Username);

            Assert.IsNotNull(user1);

            // Delete
            await UserProcessor.DeleteUser(user1.Id);

            user1 = await UserProcessor.LoadUser(TestUser.Username);

            Assert.IsNull(user1);
        }

        public async Task<User> GetCreateUser()
        {
            // Initialize api helper
            ApiHelper.InitializeClient();

            // Create
            User user = await UserProcessor.LoadUser(TestUser.Username);

            if (user == null)
                user = await UserProcessor.CreateUser(TestUser);

            return user;
        }
    }
}
