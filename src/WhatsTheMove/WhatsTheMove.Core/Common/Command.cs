using System;
using System.Windows.Input;

namespace WhatsTheMove.Core.Common
{
    public class Command : ICommand
    {

        #region Fields

        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructors

        public Command(Action<object> execute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));
            _execute = execute;
        }

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null) return _canExecute(parameter);

            return true;
        }

        public void Execute(object parameter) => _execute(parameter);        

        public void ChangeCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
