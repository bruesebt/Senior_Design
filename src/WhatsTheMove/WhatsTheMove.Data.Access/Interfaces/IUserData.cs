using System.Collections.Generic;
using System.Threading.Tasks;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Data.Interfaces
{
    public interface IUserData
    {
        Task DeleteUser(int id);
        Task<User> GetUser(int id);
        Task<User> GetUser_FromUsername(string username);
        Task<IEnumerable<User>> GetUsers();
        Task InsertUser(User user);
        Task UpdateUser(User user);
    }
}