using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.Events
{
    public delegate void LoggedInUserChangeEventHandler(object sender, LoggedInUserChangeEventArgs e);

    public class LoggedInUserChangeEventArgs : EventArgs
    {
        public bool IsUserLoggedIn { get; private set; }

        public User User { get; private set; }

        public LoggedInUserChangeEventArgs(User user)
        {
            User = user;
            IsUserLoggedIn = (User != null);
        }
    }
}
