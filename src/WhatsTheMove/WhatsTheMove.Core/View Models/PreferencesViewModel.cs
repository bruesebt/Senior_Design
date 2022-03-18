using System.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.ViewModels
{
    public class PreferencesViewModel : Common.ViewModelBase
    {
        #region Fields

        #endregion

        #region Commands

        // Commands for various UI events to bind to
        public Common.Command WhatsTheMoveCommand => new Common.Command(FindMoves);

        #endregion

        #region Constructors

        public PreferencesViewModel()
        {
            // Set default zip code
            Preference.ZipCode = LoggedInUser?.ZipCode;
        }

        #endregion

        #region Properties

        public Preference Preference
        {
            get => _preference;
            set => UpdateOnPropertyChanged(ref _preference, value);
        }
        private Preference _preference = new Preference();

        #endregion

        #region Methods

        private async void FindMoves(object param)
        {
            string results = await API.ActivityProcessor.PerformLocationSearch(Preference.ZipCode);

            //IEnumerable<Activity> activities = await API.ActivityProcessor.PerformNearbySearch(Preference);
            //Activity activity = activities.FirstOrDefault();
        }

        #endregion
    }
}
