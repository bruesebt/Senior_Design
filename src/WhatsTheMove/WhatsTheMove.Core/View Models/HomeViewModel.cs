using System;
namespace WhatsTheMove.Core.ViewModels
{
    public class HomeViewModel : Common.ViewModelBase
    {


        public Common.Command FindTheMoveCommand => new Common.Command(FindTheMove);

        private void FindTheMove(object obj)
        {
            OnChangeViewRequested(Enums.ViewRoute.SetPreferences);
        }

        public HomeViewModel()
        {
        }
    }
}
