using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.ViewModels
{
    public class LoginViewModel : Common.ViewModelBase
    {

        #region Fields

        public override IUserService UserService { get => _userService; }
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
            _userService = userService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// User property to bind to as the user attempts to log in
        /// </summary>
        public User User
        {
            get => _user;
            set => UpdateOnPropertyChanged(ref _user, value);
        }
        private User _user = new User();

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
            bool success = await UserService.LogIn(User);

            if (!success)
                UserActionResponse = "Login Failed. Please Try Again or Create an Account to Continue.";
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
