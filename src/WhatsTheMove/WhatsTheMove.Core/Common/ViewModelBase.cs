using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.Common
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event Events.ChangeViewRequestEventHandler ChangeViewRequested;

        public event Events.LoggedInUserChangeEventHandler UserChanged;

        /// <summary>
        /// The user that is currently using the application
        /// </summary>
        public User LoggedInUser
        {
            get => _loggedInUser;
            set => UpdateOnPropertyChanged(ref _loggedInUser, value);
        }
        private User _loggedInUser = null;

        /// <summary>
        /// Updates the passed in field and raises property changed event
        /// Only updates field if the value passed in is different than what the field currently is
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool UpdateOnPropertyChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        } 

        /// <summary>
        /// Raises property changed event for the specified property
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!string.IsNullOrEmpty(propertyName)) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises Change View Request for owning view to process
        /// </summary>
        /// <param name="viewRoute"></param>
        protected void OnChangeViewRequested(Enums.ViewRoute viewRoute)
        {
            ChangeViewRequested?.Invoke(this, new Events.ChangeViewRequestEventArgs(viewRoute));
        }

        /// <summary>
        /// Changes the logged in user. Pass in null to log the user out
        /// </summary>
        /// <param name="user"></param>
        protected void LoggedInUserChanged(User user)
        {
            UserChanged?.Invoke(this, new Core.Events.LoggedInUserChangeEventArgs(user));
        }
    }
}
