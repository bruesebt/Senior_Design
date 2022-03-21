using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Common;

namespace WhatsTheMove.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
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
            if (!await IsUserInputValid())
                return;

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
            //OnChangeViewRequested(Enums.ViewRoute.ForgotCredentials);
        }

        /// <summary>
        /// Checks to see whether the password and username input by the user are valid
        /// </summary>
        /// <returns></returns>
        private async Task<bool> IsUserInputValid()
        {
            string message = string.Empty;

            // Validate user credentials
            if (string.IsNullOrEmpty(User.Username))
                message = "Username cannot be empty.";
            else if (string.IsNullOrEmpty(User.Password))
                message = "Password cannot be empty.";
            else
            {
                User storedUser = await API.UserProcessor.LoadUser(User.Username);
                if (storedUser == null)
                    message = "No user with that username exists.";
                else if (!User.IsUser(storedUser))
                    message = "Incorrect password.";
            }

            // If a message is added, show to user and return 
            if (!string.IsNullOrEmpty(message))
            {
                message += " Please re-enter Username and Password and try again.";
                UserActionResponse = message;                
                User.Password = string.Empty;
                return false;
            }

            // reset password so plain text is not stored
            User.Password = string.Empty;

            return true;
        }

        #endregion

        #region Event Handlers

        #endregion

    }
}
