using System;
using WhatsTheMove.Core.Services;

namespace WhatsTheMove.Core.ViewModels

{
    public class HomeViewModel : Common.ViewModelBase
    {
        #region Fields

        private IUserService _userService;

        #endregion

        #region Commands

        public Common.Command FindTheMoveCommand => new Common.Command(FindTheMove);

        #endregion

        #region Constructors

        public HomeViewModel(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Methods

        private void FindTheMove(object obj)
        {
            OnChangeViewRequested(Enums.ViewRoute.SetPreferences);
        }

        #endregion

    }
}
