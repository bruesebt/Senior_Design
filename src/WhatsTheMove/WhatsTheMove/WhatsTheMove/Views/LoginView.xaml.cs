using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Core.ViewModels;

namespace WhatsTheMove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : UI.Common.ContentPageBase
    {
        public LoginView()
        {            
            this.BindingContext = new LoginViewModel(DependencyService.Get<IUserService>());

            InitializeComponent();

            SetContext();
        }
    }
}