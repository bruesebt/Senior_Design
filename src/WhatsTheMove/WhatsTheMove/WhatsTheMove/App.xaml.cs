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

            MainPage = new UI.Controls.NavigationMenuMain();
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
