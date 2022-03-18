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

        #endregion

        #region Methods

        private void SignUp(object param)
        {
            OnChangeViewRequested(Enums.ViewRoute.Home);
        }

        #endregion

    }
}
