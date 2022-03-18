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

            // Initialize the API Helper
            ApiHelper.InitializeClient();

            MainPage = new UI.AppShell();
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
