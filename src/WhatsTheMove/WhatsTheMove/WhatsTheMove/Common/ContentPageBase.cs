using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.UI.Common
{
    public class ContentPageBase : ContentPage
    {

        public ContentPageBase()
        {
            ((App)App.Current).UserChanged += Application_UserChanged;

            
        }

        public ViewModelBase MyContext { get => _myContext; }
        private ViewModelBase _myContext;

        public User LoggedInUser
        {
            get => _loggedInUser;
            set
            {
                _loggedInUser = value;
                if (_loggedInUser != null)
                    SetLoggedInUser();
            }
        }
        private User _loggedInUser = null;

        private async void ChangeView(string route)
        {
            try
            {
                await Shell.Current.GoToAsync(route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetLoggedInUser()
        {
            if (_myContext == null || _myContext.LoggedInUser?.Id == LoggedInUser?.Id) return;
            _myContext.LoggedInUser = LoggedInUser;
        }

        protected void SetContext()
        {
            _myContext = (ViewModelBase)this.BindingContext;

            _myContext.ChangeViewRequested += ViewModel_ChangeViewRequested;
            _myContext.UserChanged += ViewModel_UserChanged;

            this.LoggedInUser = ((App)App.Current).LoggedInUser;
        }

        private void ViewModel_UserChanged(object sender, Core.Events.LoggedInUserChangeEventArgs e)
        {
            LoggedInUser = e.User;
            ((App)App.Current).LoggedInUserChanged(LoggedInUser);
        }

        private void Application_UserChanged(object sender, Core.Events.LoggedInUserChangeEventArgs e)
        {
            this.LoggedInUser = e.User;
        }

        private void ViewModel_ChangeViewRequested(object sender, Core.Events.ChangeViewRequestEventArgs e)
        {
            try
            {
                ChangeView($"{e.ViewRoute}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
