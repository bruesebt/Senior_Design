using System;
using Xamarin.Forms;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Core.Common;
using Xamarin.Forms.Xaml;

namespace WhatsTheMove
{
    public partial class App : Application
    {
        private IUserService _userService;

        public App()
        {
            InitializeComponent();

            App.Current = this;

            // Service Dependency Injection
            DependencyService.Register<IUserService, UserService>();
            _userService = DependencyService.Get<IUserService>();
            _userService.LoggedInUserChanged += UserService_LoggedInUserChanged;
            _userService.ThemeChanged += UserService_ThemeChanged;

            // Initialize the API Helper
            ApiHelper.InitializeClient();

            // Set Theme            
            UpdateTheme();

            // Set Main Page
            if (_userService.IsUserLoggedIn)
                MainPage = new UI.AppShell();
            else
                MainPage = new Views.LoginView();
        }

        private void UserService_LoggedInUserChanged(object sender, Core.Events.LoggedInUserChangeEventArgs e)
        {
            if (_userService.IsUserLoggedIn)
            {
                if (MainPage is UI.AppShell)
                    return;
                else
                    MainPage = new UI.AppShell();
            }
            else
            {
                if (MainPage is Views.LoginView)
                    return;
                else
                    MainPage = new Views.LoginView();
            }

            UpdateTheme();
        }

        private void UserService_ThemeChanged(object sender, Core.Events.ThemeChangedEventArgs e)
        {
            UpdateTheme();
        }

        private void UpdateTheme()
        {
            if (!_userService.IsUserLoggedIn)
                return;

            OSAppTheme preferredTheme = OSAppTheme.Unspecified;
            if (_userService.LoggedInUser.IsDarkModePreferred)
                preferredTheme = OSAppTheme.Dark;
            else
                preferredTheme = OSAppTheme.Light;

            if (App.Current.UserAppTheme != preferredTheme)
                App.Current.UserAppTheme = preferredTheme;
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
