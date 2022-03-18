using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.Services
{
    public class UserService : IUserService
    {
        public User LoggedInUser { get => _loggedInUser; set => _loggedInUser = value; }
        private User _loggedInUser = new User();
    }
}
