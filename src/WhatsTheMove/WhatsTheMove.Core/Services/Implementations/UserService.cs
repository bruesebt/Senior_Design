using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Data.Common;

namespace WhatsTheMove.Core.Services
{
    public class UserService : NotifyPropertyChangedBase, IUserService
    {
        public UserService()
        {
            
        }

        public User LoggedInUser { get => _loggedInUser; set => UpdateOnPropertyChanged(ref _loggedInUser, value); }
        private User _loggedInUser = new User();

        public List<Preference> UserPreferences { get => _userPreferences; set => UpdateOnPropertyChanged(ref _userPreferences, value); }
        private List<Preference> _userPreferences = new List<Preference>();

        public Preference ActivePreference { get => _activePreference; set => UpdateOnPropertyChanged(ref _activePreference, value); }
        private Preference _activePreference = new Preference();

    }
}
