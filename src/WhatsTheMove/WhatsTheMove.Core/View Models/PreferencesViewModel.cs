using System.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Core.Enums;

namespace WhatsTheMove.Core.ViewModels
{
    public class PreferencesViewModel : Common.ViewModelBase
    {
        #region Fields

        public override IUserService UserService { get => _userService; }
        private IUserService _userService;

        #endregion

        #region Commands

        // Commands for various UI events to bind to
        public Common.Command WhatsTheMoveCommand => new Common.Command(FindMoves);

        public Common.Command ClearCommand => new Common.Command(ClearFields);

        #endregion

        #region Constructors

        public PreferencesViewModel(IUserService userService)
        {
            _userService = userService;

            Initialize();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The preference being edited 
        /// </summary>
        public Preference Preference
        {
            get => _preference;
            set => UpdateOnPropertyChanged(ref _preference, value);
        }
        private Preference _preference = new Preference();

        /// <summary>
        /// View model containing the user's preference history
        /// </summary>
        public PreferenceHistoryViewModel PreferenceHistoryVM
        {
            get => _preferenceHistory ??= new PreferenceHistoryViewModel(UserService);
        }
        private PreferenceHistoryViewModel _preferenceHistory;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes preference data
        /// </summary>
        private void Initialize()
        {
            // Set default zip code
            Preference.ZipCode = UserService.LoggedInUser?.ZipCode;

            PreferenceHistoryVM.PropertyChanged += PreferenceHistoryVM_PropertyChanged;
        }

        /// <summary>
        /// Updates active preference whenever the user selects a preference from preference history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreferenceHistoryVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(PreferenceHistoryViewModel.SelectedPreference):
                    if (PreferenceHistoryVM.SelectedPreference != null)
                        this.Preference = PreferenceHistoryVM.SelectedPreference;
                    else
                        this.ClearFields(null);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the active preference of the user and changes pages to the content page
        /// </summary>
        /// <param name="param"></param>
        private async void FindMoves(object param)
        {
            await UserService.SetActivePreference(Preference);
            OnChangeViewRequested(ViewRoute.Results, ViewRoute.SetPreferences);
        }

        /// <summary>
        /// Clears all fields 
        /// </summary>
        /// <param name="param"></param>
        private void ClearFields(object param)
        {
            Preference = new Preference();
            PreferenceHistoryVM.SelectedPreferenceString = string.Empty;
        }

        #endregion
    }
}
