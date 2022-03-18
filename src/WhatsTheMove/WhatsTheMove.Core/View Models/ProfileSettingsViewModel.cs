using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Core.Common;

namespace WhatsTheMove.Core.ViewModels
{
    public class ProfileSettingsViewModel : Common.ViewModelBase
    {

        #region Fields

        public override IUserService UserService { get => _userService; }
        private IUserService _userService;

        #endregion

        #region Commands

        public Command LogOutCommand => new Command(LogOut);

        #endregion

        #region Constructors

        public ProfileSettingsViewModel(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        private void LogOut(object param)
        {
            UserService.LogOut();
        }

        #endregion
    }
}
