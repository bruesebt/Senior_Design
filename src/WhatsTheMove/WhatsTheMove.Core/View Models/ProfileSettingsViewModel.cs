using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Core.ViewModels
{
    public class ProfileSettingsViewModel : Common.ViewModelBase
    {

        #region constructors

        public ProfileSettingsViewModel()
        {
            User = new UserViewModel();
            User.FirstName = "test";
            User.LastName = "dummy data";
            User.Address = "1234 test ave";
            User.Email = "test@test.test";
            User.Birthday = "1/1/15";
        }

        #endregion

        #region properties

        public UserViewModel User
        {
            get => _user;
            set => UpdateOnPropertyChanged(ref _user, value);
        }
        private UserViewModel _user = new UserViewModel();
        #endregion

        #region methods
        #endregion
    }
}
