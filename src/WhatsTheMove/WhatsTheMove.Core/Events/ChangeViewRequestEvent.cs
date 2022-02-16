using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Core.Events
{
    public delegate void ChangeViewRequestEventHandler(object sender, ChangeViewRequestEventArgs e);

    public class ChangeViewRequestEventArgs : EventArgs
    {
        public Enums.ViewRoute ViewRoute { get; private set; }

        public ChangeViewRequestEventArgs(Enums.ViewRoute viewRoute)
        {
            ViewRoute = viewRoute;
        }
    }
}
