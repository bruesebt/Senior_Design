﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Core.ViewModels
{
    public class LoginViewModel : Common.ViewModelBase
    {

        #region Fields

        #endregion

        #region Commands

        // Commands for various UI events to bind to
        public Common.Command LogUserInCommand => new Common.Command(LogUserIn);

        public Common.Command CreateNewAccountCommand => new Common.Command(CreateNewAccount);

        public Common.Command ForgotUsernameCommand => new Common.Command(ForgotUsername);

        public Common.Command ForgotPasswordCommand => new Common.Command(ForgotPassword);

        #endregion

        #region Constructors

        public LoginViewModel()
        {

            User = new UserViewModel()
            {
                Username = "Test Username",
                Password = "Test Password",
            };
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

        private void LogUserIn(object param)
        {
            User.Password = string.Empty;
            UserActionResponse = "Functionality not implemented yet!";
        }

        private void CreateNewAccount(object param)
        {
            OnChangeViewRequested(Enums.ViewRoute.SignUp);
        }

        private void ForgotUsername(object param)
        {

        }

        private void ForgotPassword(object param)
        {

        }

        #endregion

        #region Event Handlers

        #endregion

    }
}