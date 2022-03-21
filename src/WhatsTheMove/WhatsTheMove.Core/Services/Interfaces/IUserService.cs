using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WhatsTheMove.Core.Services
{
    public interface IUserService
    {        

        event Events.LoggedInUserChangeEventHandler LoggedInUserChanged;

        event Events.PreferenceChangedEventHandler ActivePreferenceChanged;

        event Events.ThemeChangedEventHandler ThemeChanged;

        bool IsUserLoggedIn { get; }

        User LoggedInUser { get; }

        IEnumerable<Preference> UserPreferences { get; }

        bool IsActivePreferenceValid { get; }

        Preference ActivePreference { get; }

        IEnumerable<SavedActivity> SavedActivities { get; }

        Task<bool> SignUp(User user);

        Task<bool> LogIn(User user);

        void LogOut();

        Task SetActivePreference(Preference preference);

        Task<Preference> AddPreference(Preference preference);

        Task AddSavedActivity(SavedActivity savedActivity);

        Task RemoveSavedActivity(SavedActivity savedActivity);

        Task Save();

        Task SaveUser();

        Task SavePreference();        

        Task Refresh();

        void OnLoggedInUserChanged(object sender, Events.LoggedInUserChangeEventArgs e);

        void OnActivePreferenceChanged(object sender, Events.PreferenceChangedEventArgs e);

        void OnThemeChanged(object sender, Events.ThemeChangedEventArgs e);

    }
}
