﻿using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.Services
{
    public interface IUserService
    {
        User LoggedInUser { get; set; }

        List<Preference> UserPreferences { get; set; }

        Preference ActivePreference { get; set; }

    }
}