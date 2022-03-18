using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.UI.Common;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsTheMove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotCredentialsView : ContentPageBase
    {
        public ForgotCredentialsView()
        {
            InitializeComponent();
        }
    }
}