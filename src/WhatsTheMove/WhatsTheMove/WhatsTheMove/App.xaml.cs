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

            // Initialize the API Helper
            ApiHelper.InitializeClient();

            if (_userService.IsUserLoggedIn)
                MainPage = new UI.AppShell();
            else
                MainPage = new Views.LoginView();
        }

        private void UserService_LoggedInUserChanged(object sender, Core.Events.LoggedInUserChangeEventArgs e)
        {
            if (_userService.IsUserLoggedIn)
                MainPage = new UI.AppShell();
            else
            {
                if (MainPage is Views.LoginView)
                    return;
                else
                    MainPage = new Views.LoginView();
            }
               
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
