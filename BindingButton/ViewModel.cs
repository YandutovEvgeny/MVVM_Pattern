using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BindingButton
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        double _first, _second;
        string _result;
        int _buttonContain = 1;
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                Notify("Result");
            }
        }

        public double First
        {
            get { return _first; }
            set
            {
                _first = value;
                Notify("First");
            }
        }
        public double Second
        {
            get { return _second; }
            set
            {
                _second = value;
                Notify("Second");
            }
        }

        public ICommand PlusBTN
        {
            get { return new ButtonCommand(new Action(() => Result = $"{_first} + {_second} = {_first + _second}")); }
        }
        public ICommand MinusBTN
        {
            get { return new ButtonCommand(new Action(() => Result = $"{_first} - {_second} = {_first - _second}")); }
        }
        public ICommand MultBTN
        {
            get { return new ButtonCommand(new Action(() => Result = $"{_first} * {_second} = {_first * _second}")); }
        }
        public ICommand DecBTN
        {
            get { return new ButtonCommand(new Action(() => Result = $"{_first} / {_second} = {_first / _second}")); }
        }

        public int ButtonContain
        {
            get { return _buttonContain; }
            set
            {
                _buttonContain = value;
                Notify("ButtonContain");
            }
        }
        public ICommand SquareBTN
        {
            get { return new ButtonCommand(new Action(() => ButtonContain = _buttonContain * 2)); }
        }

    }
}
