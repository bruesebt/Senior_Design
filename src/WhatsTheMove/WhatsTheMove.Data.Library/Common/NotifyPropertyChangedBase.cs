using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WhatsTheMove.Data.Common
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;        

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
    }
}
