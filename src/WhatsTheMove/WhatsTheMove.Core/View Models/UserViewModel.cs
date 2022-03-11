using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Core.ViewModels
{
    public class UserViewModel : Common.ViewModelBase
    {
        public string Username 
        { 
            get => _username; 
            set => UpdateOnPropertyChanged(ref _username, value); 
        }
        private string _username = string.Empty;

        public string Password 
        { 
            get => _password; 
            set => UpdateOnPropertyChanged(ref _password, value); 
        }
        private string _password = string.Empty;

        public string FirstName
        {
            get => _firstName;
            set => UpdateOnPropertyChanged(ref _firstName, value);
        }
        private string _firstName = string.Empty;

        public string LastName
        {
            get => _lastName;
            set => UpdateOnPropertyChanged(ref _lastName, value);
        }
        private string _lastName = string.Empty;

        public string Address
        {
            get => _address;
            set => UpdateOnPropertyChanged(ref _address, value);
        }
        private string _address = string.Empty;

        public string Email
        {
            get => _email;
            set => UpdateOnPropertyChanged(ref _email, value);
        }
        private string _email = string.Empty;

        public string Birthday
        {
            get => _birthday;
            set => UpdateOnPropertyChanged(ref _birthday, value);
        }
        private string _birthday = string.Empty;
    }
}
