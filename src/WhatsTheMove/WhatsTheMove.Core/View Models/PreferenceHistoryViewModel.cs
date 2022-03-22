using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Core.Enums;
using System.Linq;

namespace WhatsTheMove.Core.ViewModels
{
    public class PreferenceHistoryViewModel : ViewModelBase
    {

        #region Fields

        public override IUserService UserService { get => _userService; }
        private IUserService _userService;

        #endregion

        #region Constructors

        public PreferenceHistoryViewModel(IUserService userService)
        {
            _userService = userService;
            Initialize();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Dictionary of Preference where each key is string representation of a Preference, and each value is the preference Id
        /// </summary>
        public Dictionary<string, int> PreferenceDictionary
        {
            get => _preferenceDictionary ??= new Dictionary<string, int>();
            set => UpdateOnPropertyChanged(ref _preferenceDictionary, value);
        }
        private Dictionary<string, int> _preferenceDictionary;

        /// <summary>
        /// List of string representation of preferences
        /// </summary>
        public List<string> PreferenceHistory { get => PreferenceDictionary.Keys.ToList();  }

        /// <summary>
        /// String representation of preference that is actively selected
        /// </summary>
        public string SelectedPreferenceString 
        { 
            get => _selectedPreferenceString;
            set
            {
                if (UpdateOnPropertyChanged(ref _selectedPreferenceString, value))
                    UpdateSelectedPreference();
            }
        }
        private string _selectedPreferenceString;
        
        /// <summary>
        /// The Id of the preference that is actively selected
        /// </summary>
        public int SelectedPreferenceId { get => PreferenceDictionary.ContainsKey(SelectedPreferenceString) ? PreferenceDictionary[SelectedPreferenceString] : -1;  }

        /// <summary>
        /// The actual Preference object that is selected
        /// </summary>
        public Preference SelectedPreference { get => _selectedPreference; set => UpdateOnPropertyChanged(ref _selectedPreference, value); }
        private Preference _selectedPreference = null;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes preference properties in this class
        /// </summary>
        private void Initialize()
        {
            this.Refresh();
        }

        /// <summary>
        /// Refreshes preference properties in this class
        /// </summary>
        private void Refresh()
        {
            PreferenceDictionary.Add(string.Empty, 0);

            foreach (Preference preference in UserService.UserPreferences)
                if (!PreferenceDictionary.ContainsKey(preference.ToPreferenceString()))
                    PreferenceDictionary.Add(preference.ToPreferenceString(), preference.Id);

            OnPropertyChanged(nameof(PreferenceDictionary));
            OnPropertyChanged(nameof(PreferenceHistory));
        }

        /// <summary>
        /// Updates the actual selected preference object
        /// </summary>
        private void UpdateSelectedPreference()
        {
            if (SelectedPreferenceId > 0)
                SelectedPreference = UserService.UserPreferences.Where(p => p.Id == SelectedPreferenceId).First();
            else
                SelectedPreference = null;
        }

        #endregion

    }
}
