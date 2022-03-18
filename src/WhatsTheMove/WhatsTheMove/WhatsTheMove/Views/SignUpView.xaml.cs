using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhatsTheMove.UI.Common;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Core.ViewModels;

namespace WhatsTheMove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpView : ContentPageBase
    {
        public SignUpView()
        {            
            this.BindingContext = new SignUpViewModel(DependencyService.Get<IUserService>());

            InitializeComponent();

            SetContext();
        }
    }
}