using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Data.DataAccess;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Data.Interfaces;
using static WhatsTheMove.Data.Common.StoredProcedureConstants;

namespace WhatsTheMove.Data.Implementations
{
    public class UserData : IUserData
    {

        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<User>> GetUsers() =>
            _db.LoadData<User, dynamic>(storedProcedure: $"{Prefix}{nameof(User)}{GetAll}",
                                            parameters: new { });

        public async Task<User?> GetUser(int id)
        {
            var results = await _db.LoadData<User, dynamic>(storedProcedure: $"{Prefix}{nameof(User)}{Get}",
                                                                parameters: new { Id = id });

            return results.FirstOrDefault();
        }

        public async Task<User?> GetUser_FromUsername(string username)
        {
            var results = await _db.LoadData<User, dynamic>(storedProcedure: $"{Prefix}{nameof(User)}{Get}_FromUsername",
                                                                parameters: new { Username = username });

            return results.FirstOrDefault();
        }

        public async Task<User?> GetUser_FromEmail(string email)
        {
            var results = await _db.LoadData<User, dynamic>(storedProcedure: $"{Prefix}{nameof(User)}{Get}_FromEmail",
                                                                parameters: new { Email = email });

            return results.FirstOrDefault();
        }

        public Task InsertUser(User user) =>
            _db.SaveData(storedProcedure: $"{Prefix}{nameof(User)}{Insert}",
                            parameters: new { user.Username, user.Email, user.FirstName, user.LastName, user.DateOfBirth, user.ZipCode, user.Password, user.HashKey, user.ForgotPasswordKey, user.IsDarkModePreferred, user.DateAdded });

        public Task UpdateUser(User user) =>
            _db.SaveData(storedProcedure: $"{Prefix}{nameof(User)}{Update}",
                            parameters: new { user.Id, user.Username, user.Email, user.FirstName, user.LastName, user.DateOfBirth, user.ZipCode, user.Password, user.HashKey, user.ForgotPasswordKey, user.IsDarkModePreferred, user.DateAdded });

        public Task DeleteUser(int id) =>
            _db.SaveData(storedProcedure: $"{Prefix}{nameof(User)}{Delete}",
                            parameters: new { Id = id });
    }
}
