using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.Data.Common;

namespace WhatsTheMove.Data.Models
{
    public class User : NotifyPropertyChangedBase
    {       

        public int Id { get => _id; set => UpdateOnPropertyChanged(ref _id, value); }
        private int _id;

        public string Username { get => _username; set => UpdateOnPropertyChanged(ref _username, value); }
        private string _username;        

        public string Email { get => _email; set => UpdateOnPropertyChanged(ref _email, value); }
        private string _email;

        public string FirstName { get => _firstName; set => UpdateOnPropertyChanged(ref _firstName, value); }
        private string _firstName;

        public string LastName { get => _lastName; set => UpdateOnPropertyChanged(ref _lastName, value); }
        private string _lastName;

        public DateTime DateOfBirth { get => _dateOfBirth; set => UpdateOnPropertyChanged(ref _dateOfBirth, value); }
        private DateTime _dateOfBirth;

        public string ZipCode { get => _zipCode; set => UpdateOnPropertyChanged(ref _zipCode, value); }
        private string _zipCode;

        public string Password { get => _password; set => UpdateOnPropertyChanged(ref _password, value); }
        private string _password;

        public string PasswordConfirmed { get => _passwordConfirmed; set => UpdateOnPropertyChanged(ref _passwordConfirmed, value); }
        private string _passwordConfirmed;

        public string HashKey { get => _hashKey; set => UpdateOnPropertyChanged(ref _hashKey, value); }
        private string _hashKey;

        public string ForgotPasswordKey { get => _forgotPasswordKey; set => UpdateOnPropertyChanged(ref _forgotPasswordKey, value); }
        private string _forgotPasswordKey;

        public bool IsDarkModePreferred { get => _isDarkModePreferred; set => UpdateOnPropertyChanged(ref _isDarkModePreferred, value); }
        private bool _isDarkModePreferred;
        
        public DateTime DateAdded { get => _dateAdded; set => UpdateOnPropertyChanged(ref _dateAdded, value); }
        private DateTime _dateAdded;

    }
}
