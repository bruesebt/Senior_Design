using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Services;

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
            if (_userService.ActivePreference == null || _userService.ActivePreference.ZipCode == string.Empty)
            {
                this.Activities = new ObservableCollection<Activity>();
                return;
            }

            IsBusy = true;

            IEnumerable<Activity> acts = await API.ActivityProcessor.PerformNearbySearch(_userService.ActivePreference);
            this.Activities = new ObservableCollection<Activity>(acts);

            IsBusy = false;
        }

        void LoadMore(object param)
        {

        }

        public void DelayLoadMore(object param)
        {
            // TODO: Update this
            if (Activities.Count <= 10)
                return;

            LoadMore(param);
        }

        public void Clear(object param)
        {

        }

        public void Favorite(object activity)
        {
            if (activity == null) return;

            // todo
        }

        private void UserService_ActivePreferenceChanged(object sender, Events.PreferenceChangedEventArgs e)
        {
            try
            {
                this.Refresh(e.Preference);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
