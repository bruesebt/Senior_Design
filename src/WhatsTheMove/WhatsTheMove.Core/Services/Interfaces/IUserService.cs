using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;

using System.Threading.Tasks;

namespace WhatsTheMove.Core.Services
{
    public interface IUserService
    {
        event Events.LoggedInUserChangeEventHandler LoggedInUserChanged;

        bool IsUserLoggedIn { get; }

        User LoggedInUser { get; }

        IEnumerable<Preference> UserPreferences { get; }

        Preference ActivePreference { get; }

        IEnumerable<SavedActivity> SavedActivities { get; }

        Task<bool> SignUp(User user);

        Task<bool> LogIn(User user);

        void LogOut();

        Task SetActivePreference(Preference preference);

        Task<Preference> AddPreference(Preference preference);

        Task AddSavedActivity(SavedActivity savedActivity);

        Task Save();

        Task SaveUser();

        Task SavePreference();        

        Task Refresh();

        void OnLoggedInUserChanged(object sender, Events.LoggedInUserChangeEventArgs e);

    }
}
