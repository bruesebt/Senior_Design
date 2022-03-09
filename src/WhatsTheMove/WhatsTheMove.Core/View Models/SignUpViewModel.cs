using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Core.ViewModels
{
    public class SignUpViewModel : Common.ViewModelBase
    {

        #region Constructors

        public SignUpViewModel()
        {
            User = new UserViewModel()
            {
                Username = "Test Username",
                Password = "Test Password",
            };
        }

        #endregion

        #region Properties

        public UserViewModel User
        {
            get => _user;
            set => UpdateOnPropertyChanged(ref _user, value);
        }
        private UserViewModel _user = new UserViewModel();

        #endregion

        #region Methods

        #endregion

    }
}
