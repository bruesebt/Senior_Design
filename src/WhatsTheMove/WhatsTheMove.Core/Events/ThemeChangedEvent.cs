using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Core.Events
{
    public delegate void ThemeChangedEventHandler(object sender, ThemeChangedEventArgs e);

    public class ThemeChangedEventArgs : EventArgs
    {
        public bool IsDarkThemePreferred { get; set; }

        public ThemeChangedEventArgs(bool isDarkTheme)
        {
            IsDarkThemePreferred = isDarkTheme;
        }
    }
}
