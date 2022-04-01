using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Core.Enums;

namespace WhatsTheMove.Core.ViewModels
{
    public class ForgotCredentialsViewModel : ViewModelBase
    {

        #region Fields

        public override IUserService UserService { get => _userService; }
        private IUserService _userService;

        private int _attemptsRemaining = 3;

        #endregion

        #region Commands

        public Command ResetPasswordCommand => new Command(ResetPassword);

        public Command ReturnToLoginCommand => new Command(ReturnToLogin);

        public Command ValidateResetCodeCommand => new Command(ValidateResetCode);

        public Command ChangePasswordCommand => new Command(ChangePassword);

        #endregion

        #region Constructors

        public ForgotCredentialsViewModel(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// To hold user information being entered by the user
        /// </summary>
        public User User
        {
            get => _user;
            set => UpdateOnPropertyChanged(ref _user, value);
        }
        private User _user = new User();

        /// <summary>
        /// Tracks what mode this view model is currently in
        /// </summary>
        public CredentialsResetMode Mode
        {
            get => _mode;
            set => UpdateOnPropertyChanged(ref _mode, value);
        }
        private CredentialsResetMode _mode = CredentialsResetMode.EmailInput;

        /// <summary>
        /// Message to display to user when they make an action that is not appropriate
        /// </summary>
        public string UserActionResponse
        {
            get => _userActionResult;
            set => UpdateOnPropertyChanged(ref _userActionResult, value);
        }
        private string _userActionResult;

        #endregion

        #region Methods

        /// <summary>
        /// Returns the user to the login screen and resets properties
        /// </summary>
        /// <param name="param"></param>
        private void ReturnToLogin(object param)
        {
            User = new User();
            Mode = CredentialsResetMode.EmailInput;
            _attemptsRemaining = 3;
            OnChangeViewRequested(ViewRoute.Login, ViewRoute.ForgotCredentials);
        }

        /// <summary>
        /// Checks to see if the entered email address is valid, and proceeds to password 1-time reset code if valid
        /// </summary>
        /// <param name="param"></param>
        private async void ResetPassword(object param)
        {
            User tempUser = await API.UserProcessor.LoadUser_FromEmail(User.Email);

            if (tempUser != null)
            {
                await PasswordHelper.NotifyPasswordResetRequest(tempUser);
                Mode = CredentialsResetMode.CodeInput;
                UserActionResponse = string.Empty;
                _attemptsRemaining = 3;
            }
            else
            {
                _attemptsRemaining = _attemptsRemaining - 1;
                if (_attemptsRemaining == 0) ReturnToLogin(param);
                UserActionResponse = $"There is no account associated with that email address. Please re-enter email address to try again. {_attemptsRemaining} attempt(s) remaining.";
            }
        }

        /// <summary>
        /// Validates user input password reset code, and proceeds to change password fields if valid
        /// </summary>
        /// <param name="param"></param>
        private async void ValidateResetCode(object param)
        {
            User tempUser = await API.UserProcessor.LoadUser_FromEmail(User.Email);

            if (PasswordHelper.IsResetKeyValid(tempUser, User.ForgotPasswordKey))
            {                
                User.Username = tempUser.Username;
                Mode = CredentialsResetMode.PasswordInput;
                UserActionResponse = string.Empty;
            }
            else
            {                
                _attemptsRemaining = _attemptsRemaining - 1;
                if (_attemptsRemaining == 0) ReturnToLogin(param);
                UserActionResponse = $"That is not the correct 1-time password reset key. {_attemptsRemaining} attempt(s) remaining.";
            }                       
        }

        /// <summary>
        /// Validates user input and changes password if all is good. Returns to user login
        /// </summary>
        /// <param name="param"></param>
        private async void ChangePassword(object param)
        {
            User tempUser = await API.UserProcessor.LoadUser_FromEmail(User.Email);

            if (await IsUserInputValid())
            {
                tempUser.Password = User.Password;
                tempUser.PasswordConfirmed = User.PasswordConfirmed;

                PasswordHelper.UpdateUserCredentials(tempUser);
                await PasswordHelper.NotifyPasswordReset(tempUser);

                UserActionResponse = string.Empty;

                ReturnToLogin(param);
            }
        }

        /// <summary>
        /// Checks to see if user password input is valid
        /// </summary>
        /// <returns></returns>
        private async Task<bool> IsUserInputValid()
        {
            User tempUser = await API.UserProcessor.LoadUser_FromEmail(User.Email);
            string message = string.Empty;

            if (string.IsNullOrEmpty(User.Password))
                message = "Password cannot be empty.";
            else if (string.IsNullOrEmpty(User.PasswordConfirmed) || !User.Password.Equals(User.PasswordConfirmed))
                message = "Passwords must match.";
            else if (!User.Password.IsPlainTextPasswordValid())
                message = "Password must contain at least 8 characters with at least one of each: a lower case letter, an upper case letter, a number, and a special character ('@', '#', '$', '%', '^', '&', '+', '=', '!', '*', '(', ')')";
            else if (User.IsUser(tempUser))            
                message = "New password must be different than old password.";   
            
            if (!string.IsNullOrEmpty(message))
            {
                UserActionResponse = message;
                User.Password = string.Empty;
                User.PasswordConfirmed = string.Empty;
                return false;
            }

            return true;
        }

        #endregion

    }
}
