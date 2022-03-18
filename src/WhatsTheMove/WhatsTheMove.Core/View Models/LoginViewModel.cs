using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Core.Services;

namespace WhatsTheMove.Core.ViewModels
{
    public class LoginViewModel : Common.ViewModelBase
    {

        #region Fields

        private IUserService _userService;

        #endregion

        #region Commands

        // Commands for various UI events to bind to
        public Common.Command LogUserInCommand => new Common.Command(LogUserIn);

        public Common.Command CreateNewAccountCommand => new Common.Command(CreateNewAccount);

        public Common.Command ForgotCredentialsCommand => new Common.Command(ForgotCredentials);

        #endregion

        #region Constructors

        public LoginViewModel(IUserService userService)
        {

            User = new UserViewModel()
            {
                Username = "Test Username",
                Password = "Test Password",
            };

            _userService = userService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// User property to store input from user 
        /// </summary>
        public UserViewModel User
        {
            get => _tempUser;
            set => UpdateOnPropertyChanged(ref _tempUser, value);
        }
        private UserViewModel _tempUser = new UserViewModel();

        /// <summary>
        /// Message to display to the user under certain conditions
        /// </summary>
        public string UserActionResponse
        {
            get => _userActionResponse;
            set => UpdateOnPropertyChanged(ref _userActionResponse, value);
        }
        private string _userActionResponse = string.Empty;

        #endregion

        #region Methods

        private async void LogUserIn(object param)
        {
            _userService.LoggedInUser.Username = User.Username;
            OnChangeViewRequested(Enums.ViewRoute.SignUp);
        }

        private void CreateNewAccount(object param)
        {
            OnChangeViewRequested(Enums.ViewRoute.SignUp);
        }

        private void ForgotCredentials(object param)
        {
            OnChangeViewRequested(Enums.ViewRoute.ForgotCredentials);
        }

        #endregion

        #region Event Handlers

        #endregion

    }
}
