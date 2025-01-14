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
        private readonly Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuted)
        {
            _executeAction = executeAction;
            this.canExecute = canExecuted;
        }

        public bool CanExecute(object parameter)
        {
            return (bool)(canExecute?.Invoke(parameter));
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
