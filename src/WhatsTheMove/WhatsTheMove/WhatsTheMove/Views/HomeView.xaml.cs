using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace WhatsTheMove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : UI.Common.ContentPageBase
    {
        public HomeView()
        {
            this.BindingContext = new HomeViewModel(DependencyService.Get<IUserService>());

            InitializeComponent();

            SetContext();
        }

        private void btnShowMeMoves_Clicked(object sender, EventArgs e)
        {
            try
            {
                ((HomeViewModel)this.MyContext).ShowMeMovesCommand.Execute(sender);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
