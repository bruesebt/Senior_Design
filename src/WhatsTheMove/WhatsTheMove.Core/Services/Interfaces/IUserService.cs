using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;

using System.Threading.Tasks;

namespace WhatsTheMove.Core.Services
{
    public interface IUserService
    {
        bool IsUserLoggedIn { get; }

        User LoggedInUser { get; }

        IEnumerable<Preference> UserPreferences { get; }

        Preference ActivePreference { get; }

        IEnumerable<SavedActivity> SavedActivities { get; }

        Task SignUp(User user);

        void LogIn(User user);

        void LogOut();

        Task SetActivePreference(Preference preference);

        Task<Preference> AddPreference(Preference preference);

        Task AddSavedActivity(SavedActivity savedActivity);

        Task Save();

        Task SaveUser();

        Task SavePreference();        

        Task Refresh();

    }
}
