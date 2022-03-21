using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Core.Enums;
using WhatsTheMove.Data.Models;
using System.Linq;

namespace WhatsTheMove.UI.Common
{
    public class ContentPageBase : ContentPage
    {

        public ContentPageBase()
        {

        }

        public ViewModelBase MyContext { get => _myContext; }
        private ViewModelBase _myContext;

        private async void ChangeView(string routeTo, string routeFrom)
        {
            try
            {
                switch (routeTo)
                {
                    case nameof(ViewRoute.SignUp):
                        App.Current.MainPage = new Views.SignUpView();
                        break;
                    case nameof(ViewRoute.Login):
                        App.Current.MainPage = new Views.LoginView();
                        break;
                    default:
                        await Shell.Current.GoToAsync(routeTo);
                        break;
                }

                switch (routeFrom)
                {
                    case nameof(ViewRoute.ProfileSettings):
                    case nameof(ViewRoute.ApplicationSettings):
                        MyContext.Save();
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void SetContext()
        {
            _myContext = (ViewModelBase)this.BindingContext;

            _myContext.ChangeViewRequested += ViewModel_ChangeViewRequested;
        }

        private void ViewModel_ChangeViewRequested(object sender, Core.Events.ChangeViewRequestEventArgs e)
        {
            try
            {
                ChangeView($"{e.ViewRouteTo}", $"{e.ViewRouteFrom}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
