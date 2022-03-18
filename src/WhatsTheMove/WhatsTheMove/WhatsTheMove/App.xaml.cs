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
        public event Core.Events.LoggedInUserChangeEventHandler UserChanged;

        public App()
        {
            InitializeComponent();

            App.Current = this;

            // Service Dependency Injection
            DependencyService.Register<IUserService, UserService>();

            // Initialize the API Helper
            ApiHelper.InitializeClient();

            MainPage = new UI.AppShell();
        }

        public User LoggedInUser
        {
            get => _loggedInUser;
            set => _loggedInUser = value;
        }
        private User _loggedInUser = null;

        public void LoggedInUserChanged(User user)
        {
            LoggedInUser = user;
            UserChanged?.Invoke(this, new Core.Events.LoggedInUserChangeEventArgs(user));
        }

        protected override void OnStart()
        {
            // log user in if already logged in? 
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
