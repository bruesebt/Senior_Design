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

        #region Events

        public event Events.LoggedInUserChangeEventHandler LoggedInUserChanged;

        public event Events.PreferenceChangedEventHandler ActivePreferenceChanged;

        #endregion

        #region Constructors

        public UserService()
        {

        }

        #endregion

        #region Properties

        public bool IsUserLoggedIn => LoggedInUser != null;        

        public User LoggedInUser
        {
            get => _loggedInUser;
            private set
            {
                UpdateOnPropertyChanged(ref _loggedInUser, value);
                OnLoggedInUserChanged(this, new Events.LoggedInUserChangeEventArgs(_loggedInUser));
            }
        }

        private User _loggedInUser;

        public IEnumerable<Preference> UserPreferences { get => _userPreferences; private set => UpdateOnPropertyChanged(ref _userPreferences, value); }
        private IEnumerable<Preference> _userPreferences;

        public bool IsActivePreferenceValid => ActivePreference != null;

        public Preference ActivePreference 
        { 
            get => _activePreference;
            private set
            {
                UpdateOnPropertyChanged(ref _activePreference, value);
                OnActivePreferenceChanged(this, new Events.PreferenceChangedEventArgs(_activePreference));
            }
        }
        private Preference _activePreference;

        public IEnumerable<SavedActivity> SavedActivities { get => _savedActivities; set => UpdateOnPropertyChanged(ref _savedActivities, value); }
        private IEnumerable<SavedActivity> _savedActivities;

        #endregion

        #region Methods

        public async Task<bool> SignUp(User user)
        {
            bool userExists = (await API.UserProcessor.LoadUser(user.Username)) != null;

            if (!userExists)
                await LogIn(await API.UserProcessor.CreateUser(user));
            else
                return false;

            return true;
        }

        public async Task<bool> LogIn(User user)
        {
            User thisUser = await API.UserProcessor.LoadUser(user.Username);
            bool isValidUser = thisUser != null;

            if (!isValidUser)
                return false;

            LoggedInUser = thisUser;
            OnPropertyChanged(nameof(IsUserLoggedIn));

            return true;
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

            preference.UserId = LoggedInUser.Id;

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

        public void OnLoggedInUserChanged(object sender, Events.LoggedInUserChangeEventArgs e)
        {
            LoggedInUserChanged?.Invoke(sender, e);
        }

        public void OnActivePreferenceChanged(object sender, Events.PreferenceChangedEventArgs e)
        {
            ActivePreferenceChanged?.Invoke(sender, e);
        }

        #endregion

    }
}
