using System;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.ViewModels

{
    public class HomeViewModel : Common.ViewModelBase
    {
        #region Fields

        public override IUserService UserService { get => _userService;  }
        private IUserService _userService;

        #endregion

        #region Commands

        public Common.Command FindTheMoveCommand => new Common.Command(FindTheMove);

        public Common.Command MyFavoriteMovesCommand => new Common.Command(MyFavoriteMoves);

        public Common.Command ShowMeMovesCommand => new Common.Command(ShowMeMoves);

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

        private void MyFavoriteMoves(object param)
        {
            OnChangeViewRequested(Enums.ViewRoute.FavoriteActivities);
        }

        private void ShowMeMoves(object param)
        {
            Preference preference = new Preference()
            {
                ZipCode = UserService.LoggedInUser.ZipCode,
                Distance = 10,
                Budget = 1,
                IsDrinksRequested = true
            };

            UserService.SetActivePreference(preference);
            OnChangeViewRequested(Enums.ViewRoute.Results);
        }

        #endregion

    }
}
