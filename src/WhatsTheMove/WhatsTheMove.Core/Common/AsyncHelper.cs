using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatsTheMove.Core.Common
{
    public static class AsyncHelper
    {

        #region Fields

        private static CancellationTokenSource _throttleCts = new CancellationTokenSource();

        #endregion

        /// <summary>
        /// Runs in a background thread, checks for new Query and runs current one
        /// </summary>
        public static async Task DelayedAction(Func<object, Task> action, object param, int delayInMiliseconds)
        {
            try
            {
                Interlocked.Exchange(ref _throttleCts, new CancellationTokenSource()).Cancel();
                await Task.Delay(TimeSpan.FromMilliseconds(delayInMiliseconds), _throttleCts.Token)
                  .ContinueWith(async task => await action(param),
                                CancellationToken.None,
                                TaskContinuationOptions.OnlyOnRanToCompletion,
                                TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch
            {
                //Ignore any Threading errors
            }
        }
    }
}
