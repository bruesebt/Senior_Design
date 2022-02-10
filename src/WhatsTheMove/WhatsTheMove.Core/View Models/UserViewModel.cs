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
    }
}
