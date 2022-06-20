using System;
using System.Windows.Input;

namespace TelephoneBook
{
    class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action _action;
        public ButtonCommand(Action action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
