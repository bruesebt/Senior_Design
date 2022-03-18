using System;
using System.Collections.Generic;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.API;
using WhatsTheMove.Core.Common;
using System.Threading.Tasks;

namespace WhatsTheMove.Core.Tests
{
    public static class UserApiProcessorTest
    {
        public static async Task UserProcessor_CRUD_Test()
        {
            try
            {
                // Initialize a new user
                User testUser = new User()
                {
                    Username = "cargilch",
                    FirstName = "Caleb",
                    LastName = "Cargill",
                    DateOfBirth = new System.DateTime(year: 1999, month: 1, day: 25),
                    ZipCode = "45245",
                    Password = "a6e5rg14a6r5g16awe85r1g6r8gb",
                    PasswordConfirmed = "a6e5rg14a6r5g16awe85r1g6r8gb",
                    HashKey = "a6e5rg14a6r5g16awe85r1g6r8gb",
                    ForgotPasswordKey = null,
                    IsDarkModePreferred = true,
                    DateAdded = System.DateTime.Now
                };

                // Initialize api helper
                ApiHelper.InitializeClient();

                // Create
                User user = await UserProcessor.CreateUser(testUser);

                // Read
                IEnumerable<User> users = await UserProcessor.LoadUsers();

                User user1 = await UserProcessor.LoadUser(testUser.Username);

                User user2 = await UserProcessor.LoadUser(user1.Id);

                // Update
                user2 = new User()
                {
                    Id = user2.Id,
                    Username = "cargilch1",
                    FirstName = "Caleb1",
                    LastName = "Cargill1",
                    DateOfBirth = new System.DateTime(year: 1990, month: 1, day: 25),
                    ZipCode = "45219",
                    Password = "asgarghrewhaerhaergbaerg",
                    PasswordConfirmed = "asgarghrewhaerhaergbaerg",
                    HashKey = "asgarghrewhaerhaergbaerg",
                    ForgotPasswordKey = null,
                    IsDarkModePreferred = false,
                    DateAdded = System.DateTime.Now
                };

                user2 = await UserProcessor.UpdateUser(user2);

                // Delete
                await UserProcessor.DeleteUser(user2.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
