using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Common;

namespace WhatsTheMove.Data.Models
{
    public class SavedActivity : NotifyPropertyChangedBase
    {
        public int Id { get => _id; set => UpdateOnPropertyChanged(ref _id, value); }
        private int _id;

        public int UserId { get => _userId; set => UpdateOnPropertyChanged(ref _userId, value); }
        private int _userId;

        public int PreferenceId { get => _preferenceId; set => UpdateOnPropertyChanged(ref _preferenceId, value); }
        private int _preferenceId;

        public string Place_Id { get => _place_Id; set => UpdateOnPropertyChanged(ref _place_Id, value); }
        private string _place_Id;

        public string Name { get => _name; set => UpdateOnPropertyChanged(ref _name, value); }
        private string _name;

        public int? Rating { get => _rating; set => UpdateOnPropertyChanged(ref _rating, value); }
        private int? _rating;

        public DateTime DateAdded { get => _dateAdded; set => UpdateOnPropertyChanged(ref _dateAdded, value); }
        private DateTime _dateAdded;

    }
}
