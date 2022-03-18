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

            IsBusy = false;
            List<Activity> acts = new List<Activity>();
            acts.Add(new Activity()
            {
                Name = "Test Activity",
                Icon_Mask_Base_Uri = @"https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fen%2Fthumb%2F3%2F32%2FWendy%2527s_full_logo_2012.svg%2F800px-Wendy%2527s_full_logo_2012.svg.png&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FWendy%2527s&tbnid=cQlCa-xo5V87VM&vet=12ahUKEwj4wOeCuM72AhUnQ0IHHRukDfkQMygAegUIARDbAQ..i&docid=ZfHJwCaHgJcLIM&w=800&h=674&q=wendy%27s&ved=2ahUKEwj4wOeCuM72AhUnQ0IHHRukDfkQMygAegUIARDbAQ",
                User_Ratings_Total = 40
            });
            acts.Add(new Activity()
            {
                Name = "Test Activity 2",
                Icon_Mask_Base_Uri = @"https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fen%2Fthumb%2F3%2F32%2FWendy%2527s_full_logo_2012.svg%2F800px-Wendy%2527s_full_logo_2012.svg.png&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FWendy%2527s&tbnid=cQlCa-xo5V87VM&vet=12ahUKEwj4wOeCuM72AhUnQ0IHHRukDfkQMygAegUIARDbAQ..i&docid=ZfHJwCaHgJcLIM&w=800&h=674&q=wendy%27s&ved=2ahUKEwj4wOeCuM72AhUnQ0IHHRukDfkQMygAegUIARDbAQ",
                User_Ratings_Total = 30
            });
            Activities = new ObservableCollection<Activity>(acts);
        }

        #endregion

        #region Properties

        public bool IsBusy { get; set; }

        public ObservableCollection<Activity> Activities 
        { 
            get => _activities; 
            set => UpdateOnPropertyChanged(ref _activities, value); 
        }
        private ObservableCollection<Activity> _activities;

        public Activity SelectedActivity { get; set; }

        #endregion

        #region Methods

        private void Refresh(object param)
        {

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

        #endregion
    }
}
