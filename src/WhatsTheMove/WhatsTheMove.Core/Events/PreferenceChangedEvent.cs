using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.Events
{
    public delegate void PreferenceChangedEventHandler(object sender, PreferenceChangedEventArgs e);

    public class PreferenceChangedEventArgs : EventArgs
    {
        public Preference Preference { get; set; }

        public PreferenceChangedEventArgs(Preference preference)
        {
            Preference = preference;
        }
    }
}
