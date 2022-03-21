using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Services;
using System.Threading.Tasks;

namespace WhatsTheMove.Core.ViewModels
{
    public class FavoriteActivitiesViewModel : ViewModelBase
    {
        #region Fields

        public override IUserService UserService { get => _userService; }
        private IUserService _userService;

        #endregion

        #region Commands

        public Command RefreshCommand => new Command(Refresh);

        public Command UnFavoriteCommand => new Command(UnFavorite);

        #endregion

        #region Constructors

        public FavoriteActivitiesViewModel(IUserService userService)
        {
            _userService = userService;            
            this.Refresh(null);
        }

        #endregion

        #region Properties

        public bool IsBusy { get => _isBusy; set => UpdateOnPropertyChanged(ref _isBusy, value); }
        private bool _isBusy = false;

        public ObservableCollection<Activity> Activities
        {
            get => _activities;
            set => UpdateOnPropertyChanged(ref _activities, value);
        }
        private ObservableCollection<Activity> _activities;

        public Activity SelectedActivity { get; set; }

        #endregion

        #region Methods

        private async void Refresh(object param)
        {
            await UpdateActivities();
        }

        private async Task UpdateActivities()
        {
            if (!UserService.IsUserLoggedIn || !UserService.SavedActivities.Any())
            {
                this.Activities = new ObservableCollection<Activity>();
                return;
            }

            IsBusy = true;

            IEnumerable<Activity> acts = await API.ActivityProcessor.PerformDetailsSearch(UserService.SavedActivities);
            this.Activities = new ObservableCollection<Activity>(acts);

            IsBusy = false;
        }

        public async void UnFavorite(object activity)
        {
            if (activity == null) return;

            Activity activityToRemove = (Activity)activity;

            SavedActivity savedActivity = UserService.SavedActivities.Where(sa => sa.Place_Id == activityToRemove.Place_Id).First();

            await UserService.RemoveSavedActivity(savedActivity);

            await UpdateActivities();
        }

        #endregion
    }
}
