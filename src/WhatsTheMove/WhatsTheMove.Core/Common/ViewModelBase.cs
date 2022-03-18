using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Services;
using WhatsTheMove.Data.Common;

namespace WhatsTheMove.Core.Common
{
    public class ViewModelBase : NotifyPropertyChangedBase
    {
        public event Events.ChangeViewRequestEventHandler ChangeViewRequested;

        /// <summary>
        /// The service shared between view models by dependency injection holding the active user's information
        /// </summary>
        public virtual IUserService UserService { get; }        

        /// <summary>
        /// Raises Change View Request for owning view to process
        /// </summary>
        /// <param name="viewRoute"></param>
        protected void OnChangeViewRequested(Enums.ViewRoute viewRoute)
        {
            ChangeViewRequested?.Invoke(this, new Events.ChangeViewRequestEventArgs(viewRoute));
        }
    }
}
