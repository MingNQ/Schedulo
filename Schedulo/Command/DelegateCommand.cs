using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Schedulo.Command
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Func<object, object> _canExecuteAction;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> executeAction, Func<object, object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object parameter)
        {
            return (bool)(_canExecuteAction?.Invoke(parameter));
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }

        public void InvokeCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
