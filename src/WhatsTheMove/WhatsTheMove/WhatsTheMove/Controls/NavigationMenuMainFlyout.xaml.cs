using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsTheMove.UI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationMenuMainFlyout : ContentPage
    {
        public ListView ListView;

        public NavigationMenuMainFlyout()
        {
            InitializeComponent();

            BindingContext = new NavigationMenuMainFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class NavigationMenuMainFlyoutViewModel : WhatsTheMove.Core.Common.ViewModelBase
        {
            public ObservableCollection<NavigationMenuMainFlyoutMenuItem> MenuItems { get; set; }

            public NavigationMenuMainFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<NavigationMenuMainFlyoutMenuItem>(new[]
                {
                    new NavigationMenuMainFlyoutMenuItem { Id = 0, Title = "Find Activities", TargetType=typeof(WhatsTheMove.Views.ResultsView)},
                    new NavigationMenuMainFlyoutMenuItem { Id = 1, Title = "Edit Preferences", TargetType=typeof(WhatsTheMove.Views.EditPreferencesView) }
                });
            }

        }
    }
}