using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Core.Services;

namespace WhatsTheMove.Core.ViewModels
{
    public class AppSettingsViewModel : ViewModelBase
    {
        #region Fields

        public override IUserService UserService {get => _userService; }
        private IUserService _userService;

        #endregion

        #region Commands

        #endregion

        #region Constructors 

        public AppSettingsViewModel(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

    }
}
