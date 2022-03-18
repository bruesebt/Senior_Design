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
