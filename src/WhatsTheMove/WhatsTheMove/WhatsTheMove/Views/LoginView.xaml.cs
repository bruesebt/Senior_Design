using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsTheMove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            // Set Context of View. View will look inside this context for properties that are binded to
            this.BindingContext = new WhatsTheMove.Core.ViewModels.LoginViewModel();

            InitializeComponent();
        }
    }
}