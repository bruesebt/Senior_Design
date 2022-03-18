using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Services;

namespace WhatsTheMove.Core.ViewModels
{
    public class SignUpViewModel : Common.ViewModelBase
    {

        #region Fields

        public override IUserService UserService { get => _userService; }
        private IUserService _userService;

        #endregion

        #region Commands

        public Common.Command SignUpCommand => new Common.Command(SignUp);

        #endregion

        #region Constructors

        public SignUpViewModel(IUserService userService)
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

        #endregion

        #region Methods

        private async void SignUp(object param)
        {
            await UserService.SignUp(User);
            OnChangeViewRequested(Enums.ViewRoute.Home);
        }

        #endregion

    }
}
