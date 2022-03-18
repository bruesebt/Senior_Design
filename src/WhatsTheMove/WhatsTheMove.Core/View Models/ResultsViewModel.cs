using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.ViewModels
{
    public class ResultsViewModel : ViewModelBase
    {

        #region Commands

        public Command RefreshCommand => new Command(Refresh);

        public Command DelayLoadMoreCommand => new Command(DelayLoadMore);

        #endregion

        #region Constructors

        public ResultsViewModel()
        {

        }

        #endregion

        #region Properties

        public bool IsBusy { get; set; }

        public ObservableCollection<IGrouping<string, Activity>> ActivityGroups { get; }

        public Activity SelectedActivity { get; set; }

        #endregion

        #region Methods

        private void Refresh(object param)
        {

        }

        void LoadMore(object param)
        {

        }

        void DelayLoadMore(object param)
        {
            // TODO: Update this
            if (ActivityGroups.Count <= 10)
                return;

            LoadMore(param);
        }

        #endregion
    }
}
