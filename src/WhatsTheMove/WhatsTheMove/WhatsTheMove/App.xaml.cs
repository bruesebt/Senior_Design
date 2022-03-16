using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsTheMove
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Initialize the API Helper
            WhatsTheMove.Core.Common.ApiHelper.InitializeClient();

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
