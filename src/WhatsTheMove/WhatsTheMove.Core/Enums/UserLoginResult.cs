using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Core.Enums
{
    public enum UserLoginResult
    {
        None = 0,
        InvalidUsername = 1,
        IncorrectPassword = 2,
        EmptyUsername = 3,
        EmptyPassword = 4
    }
}
