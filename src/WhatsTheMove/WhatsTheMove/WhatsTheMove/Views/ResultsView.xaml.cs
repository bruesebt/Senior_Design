using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.UI.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Core.ViewModels;

namespace WhatsTheMove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsView : ContentPageBase
    {
        public ResultsView()
        {
            this.BindingContext = new ResultsViewModel(DependencyService.Get<IUserService>());

            InitializeComponent();

            SetContext();
        }
    }
}