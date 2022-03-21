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
    public class ResultsViewModel : ViewModelBase
    {

        #region Fields

        public override IUserService UserService { get => _userService; }
        private IUserService _userService;

        #endregion

        #region Commands

        public Command RefreshCommand => new Command(Refresh);

        public Command DelayLoadMoreCommand => new Command(DelayLoadMore);

        public Command FavoriteCommand => new Command(Favorite);

        public Command UnFavoriteCommand => new Command(UnFavorite);

        public Command LoadMoreCommand => new Command(LoadMore);

        public Command ClearCommand => new Command(Clear);

        #endregion

        #region Constructors

        public ResultsViewModel(IUserService userService)
        {
            _userService = userService;
            _userService.ActivePreferenceChanged += UserService_ActivePreferenceChanged;
            this.Refresh(null);
        }

        #endregion

        #region Properties

        public bool IsFavoritesShown 
        { 
            get => _isFavoritesShown;
            set
            {
                UpdateOnPropertyChanged(ref _isFavoritesShown, value);
                FilterFavorites();
            }
        }
        private bool _isFavoritesShown = false;

        public bool IsBusy { get => _isBusy; set => UpdateOnPropertyChanged(ref _isBusy, value); }
        private bool _isBusy = false;

        public ObservableCollection<Activity> Activities 
        { 
            get => !IsFavoritesShown 
                        ? _activities 
                        : new ObservableCollection<Activity>(_activities.Where(a => UserService.SavedActivities.Select(sa => sa.Place_Id).Contains(a.Place_Id))); 
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
            if (!_userService.IsActivePreferenceValid)
            {
                this.Activities = new ObservableCollection<Activity>();
                return;
            }

            IsBusy = true;

            IEnumerable<Activity> acts = await API.ActivityProcessor.PerformNearbySearch(_userService.ActivePreference);
            this.Activities = new ObservableCollection<Activity>(acts);

            FilterFavorites();

            IsBusy = false;
        }

        void LoadMore(object param)
        {

        }

        public void DelayLoadMore(object param)
        {
            // TODO: Update this
            if (Activities.Count <= 20)
                return;

            LoadMore(param);
        }

        public void Clear(object param)
        {

        }

        public async void Favorite(object activity)
        {
            if (activity == null) return;

            Activity activityToSave = (Activity)activity;

            SavedActivity savedActivity = new SavedActivity()
            {
                UserId = UserService.LoggedInUser.Id,
                PreferenceId = UserService.ActivePreference.Id,
                Place_Id = activityToSave.Place_Id,
                Name = activityToSave.Name,
                Rating = (int)Math.Round(activityToSave.Rating),
                DateAdded = DateTime.Now
            };

            await UserService.AddSavedActivity(savedActivity);
        }

        public async void UnFavorite(object activity)
        {
            if (activity == null) return;

            Activity activityToRemove = (Activity)activity;

            SavedActivity savedActivity = UserService.SavedActivities.Where(sa => sa.Place_Id == activityToRemove.Place_Id).First();

            await UserService.RemoveSavedActivity(savedActivity);

            FilterFavorites();
        }

        private async void UserService_ActivePreferenceChanged(object sender, Events.PreferenceChangedEventArgs e)
        {
            try
            {
                await this.UpdateActivities();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FilterFavorites()
        {
            OnPropertyChanged(nameof(Activities));
        }

        #endregion
    }
}
