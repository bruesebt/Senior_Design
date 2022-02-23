using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhatsTheMove.Core.Common;

namespace WhatsTheMove.UI.Common
{
    public class ContentPageBase : ContentPage
    {

        public ContentPageBase()
        {
                        
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

        private async void ChangeView(string route)
        {            
            await Shell.Current.GoToAsync(route);
        }

        public ViewModelBase MyContext { get => _myContext; }
        private ViewModelBase _myContext;

        protected void SetContext()
        {
            _myContext = (ViewModelBase)this.BindingContext;

            _myContext.ChangeViewRequested += ViewModel_ChangeViewRequested;
        }

    }
}
