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
            
        }

        public ViewModelBase MyContext { get => _myContext; }
        private ViewModelBase _myContext;

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

        protected void SetContext()
        {
            _myContext = (ViewModelBase)this.BindingContext;

            _myContext.ChangeViewRequested += ViewModel_ChangeViewRequested;                       
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
