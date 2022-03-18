using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Data.Common;
using System.Threading.Tasks;

namespace WhatsTheMove.Core.Services
{
    public class UserService : NotifyPropertyChangedBase, IUserService
    {
        public UserService()
        {

        }

        public bool IsUserLoggedIn => LoggedInUser != null;

        public User LoggedInUser { get => _loggedInUser; private set => UpdateOnPropertyChanged(ref _loggedInUser, value); }
        private User _loggedInUser = new User();

        public IEnumerable<Preference> UserPreferences { get => _userPreferences; private set => UpdateOnPropertyChanged(ref _userPreferences, value); }
        private IEnumerable<Preference> _userPreferences;

        public Preference ActivePreference { get => _activePreference; private set => UpdateOnPropertyChanged(ref _activePreference, value); }
        private Preference _activePreference = new Preference();

        public IEnumerable<SavedActivity> SavedActivities { get => _savedActivities; set => UpdateOnPropertyChanged(ref _savedActivities, value); }
        private IEnumerable<SavedActivity> _savedActivities;

        public async Task SignUp(User user)
        {
            bool userExists = (await API.UserProcessor.LoadUser(user.Username)) != null;

            if (!userExists)
                LogIn(await API.UserProcessor.CreateUser(user));
            else
                throw new Exception(message: $"A user with username {user.Username} already exists.");
        }

        public void LogIn(User user)
        {
            LoggedInUser = user;
            OnPropertyChanged(nameof(IsUserLoggedIn));
        }

        public void LogOut()
        {
            LoggedInUser = null;
            OnPropertyChanged(nameof(IsUserLoggedIn));
        }

        public async Task SetActivePreference(Preference preference)
        {
            if (!IsUserLoggedIn || preference == null) return;

            ActivePreference = await AddPreference(preference);            
        }

        public async Task<Preference> AddPreference(Preference preference)
        {
            if (!IsUserLoggedIn || preference == null) return null;

            preference =  await API.PreferenceProcessor.CreatePreference(preference);
            await Refresh();
            return preference;
        }

        public async Task AddSavedActivity(SavedActivity savedActivity)
        {
            if (!IsUserLoggedIn || savedActivity == null) return;

            await API.SavedActivityProcessor.CreateSavedActivity(savedActivity);
            await Refresh();
        }

        public async Task Save()
        {
            await SaveUser();
            await SavePreference();            
        }

        public async Task SaveUser()
        {
            if (!IsUserLoggedIn) return;

            LoggedInUser = await API.UserProcessor.UpdateUser(LoggedInUser);
        }

        public async Task SavePreference()
        {
            if (!IsUserLoggedIn || ActivePreference == null) return;

            ActivePreference = await API.PreferenceProcessor.UpdatePreference(ActivePreference);
        }

        public async Task Refresh()
        {
            if (!IsUserLoggedIn) return;

            UserPreferences = await API.PreferenceProcessor.LoadPreferences(LoggedInUser.Id);
            SavedActivities = await API.SavedActivityProcessor.LoadSavedActivities(LoggedInUser.Id);
        }
    }
}
