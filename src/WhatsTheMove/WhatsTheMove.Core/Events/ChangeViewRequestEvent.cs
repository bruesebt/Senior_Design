using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Core.Events
{
    public delegate void ChangeViewRequestEventHandler(object sender, ChangeViewRequestEventArgs e);

    public class ChangeViewRequestEventArgs : EventArgs
    {
        public Enums.ViewRoute ViewRouteTo { get; private set; }

        public Enums.ViewRoute ViewRouteFrom { get; private set; }

        public ChangeViewRequestEventArgs(Enums.ViewRoute viewRouteTo, Enums.ViewRoute viewRouteFrom)
        {
            ViewRouteTo = viewRouteTo;
            ViewRouteFrom = viewRouteFrom;
        }
    }
}
