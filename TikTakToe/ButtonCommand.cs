﻿using System;
using System.Windows.Input;

namespace TikTakToe
{
    class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<object> _action;
        public ButtonCommand(Action<object> action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
