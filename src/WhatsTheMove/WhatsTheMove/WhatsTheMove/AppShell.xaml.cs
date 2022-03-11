using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsTheMove.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            
            InitializeComponent();

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute($"{Core.Enums.ViewRoute.Login}", typeof(Views.LoginView));
            Routing.RegisterRoute($"{Core.Enums.ViewRoute.SignUp}", typeof(Views.SignUpView));
            Routing.RegisterRoute($"{Core.Enums.ViewRoute.ForgotCredentials}", typeof(Views.ForgotCredentialsView));
            Routing.RegisterRoute($"{Core.Enums.ViewRoute.SetPreferences}", typeof(Views.EditPreferencesView));
            Routing.RegisterRoute($"{Core.Enums.ViewRoute.Results}", typeof(Views.ResultsView));
            Routing.RegisterRoute($"{Core.Enums.ViewRoute.ProfileSettings}", typeof(Views.ProfileSettingsView));
            Routing.RegisterRoute($"{Core.Enums.ViewRoute.Home}", typeof(Views.HomeView));
        }
    }
}