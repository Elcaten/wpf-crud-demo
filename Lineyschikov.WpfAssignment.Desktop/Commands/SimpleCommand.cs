using System;
using System.Windows.Input;

namespace Lineyschikov.WpfAssignment.Desktop.Commands
{
    public class SimpleCommand : ICommand
    {
        private readonly Action _action;

        public event EventHandler CanExecuteChanged;

        public SimpleCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_action != null) _action();
        }
    }
}