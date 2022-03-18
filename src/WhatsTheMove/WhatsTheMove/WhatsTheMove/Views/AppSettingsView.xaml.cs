using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using WhatsTheMove.UI.Common;
using Xamarin.Forms.Xaml;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Core.ViewModels;

namespace WhatsTheMove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppSettingsView : ContentPageBase
    {
        public AppSettingsView()
        {
            this.BindingContext = new AppSettingsViewModel(DependencyService.Get<IUserService>());

            InitializeComponent();

            SetContext();
        }
    }
}