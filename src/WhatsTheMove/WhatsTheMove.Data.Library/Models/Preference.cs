using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Common;

namespace WhatsTheMove.Data.Models
{
    public class Preference : NotifyPropertyChangedBase
    {

        public int Id { get => _id; set => UpdateOnPropertyChanged(ref _id, value); }
        private int _id;

        public int UserId { get => _userId; set => UpdateOnPropertyChanged(ref _userId, value); }
        private int _userId;

        public string ZipCode { get => _zipCode; set => UpdateOnPropertyChanged(ref _zipCode, value); }
        private string _zipCode;

        public int? Distance { get => _distance; set => UpdateOnPropertyChanged(ref _distance, value); }
        private int? _distance;
        
        public int? GroupSize { get => _groupSize; set => UpdateOnPropertyChanged(ref _groupSize, value); }
        private int? _groupSize;

        public bool? IsFoodRequested { get => _isFoodRequested; set => UpdateOnPropertyChanged(ref _isFoodRequested, value); }
        private bool? _isFoodRequested;

        public bool? IsDrinksRequested { get => _isDrinksRequested; set => UpdateOnPropertyChanged(ref _isDrinksRequested, value); }
        private bool? _isDrinksRequested;

        public int? EnergyLevel { get => _energyLevel; set => UpdateOnPropertyChanged(ref _energyLevel, value); }
        private int? _energyLevel;

        public int? Budget { get => _budget; set => UpdateOnPropertyChanged(ref _budget, value); }
        private int? _budget;

        public int? TimeOfDay { get => _timeOfDay; set => UpdateOnPropertyChanged(ref _timeOfDay, value); }
        private int? _timeOfDay;

        public int? DressCode { get => _dressCode; set => UpdateOnPropertyChanged(ref _dressCode, value); }
        private int? _dressCode;

        public DateTime DateAdded { get => _dateAdded; set => UpdateOnPropertyChanged(ref _dateAdded, value); }
        private DateTime _dateAdded = DateTime.Now;

    }
}
