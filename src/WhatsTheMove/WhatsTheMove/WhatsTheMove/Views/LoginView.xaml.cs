using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsTheMove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : UI.Common.ContentPageBase
    {
        public LoginView()
        {
            InitializeComponent();

            SetContext();
        }
    }
}