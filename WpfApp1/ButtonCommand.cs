using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action _action;
        public ButtonCommand(Action action)
        {
            _action = action;
        }

        //Проверка активна кнопка или нет
        public bool CanExecute(object parameter)
        {
            return true;
        }

        //Метод, который срабатывает при нажатии на кнопки
        public void Execute(object parameter)
        {
            _action();
        }
    }
}
