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

        public User User
        {
            get => _user;
            set => UpdateOnPropertyChanged(ref _user, value);
        }
        private User _user = new User();

        public CredentialsResetMode Mode
        {
            get => _mode;
            set => UpdateOnPropertyChanged(ref _mode, value);
        }
        private CredentialsResetMode _mode = CredentialsResetMode.EmailInput;

        #endregion

        #region Methods

        private void ReturnToLogin(object param)
        {
            User = new User();
            Mode = CredentialsResetMode.EmailInput;
            OnChangeViewRequested(ViewRoute.Login, ViewRoute.ForgotCredentials);
        }

        private void ResetPassword(object param)
        {
            Mode = CredentialsResetMode.CodeInput;
        }

        private void ValidateResetCode(object param)
        {
            Mode = CredentialsResetMode.PasswordInput;
            User.Username = "cargilch";
        }

        private void ChangePassword(object param)
        {
            ReturnToLogin(param);
        }

        #endregion

    }
}
