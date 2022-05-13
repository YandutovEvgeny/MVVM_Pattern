using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExampleMVVM
{
    class ViewModel2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        byte r,g,b;
        SolidColorBrush colorBrush;
        Sum model;
        int firstNumber, secondNumber, sum;

        public int Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                Notify("Sum");
            }
        }
        public int FirstNumber
        {
            get { return firstNumber; }
            set
            {
                firstNumber = value;
                Sum = model.summa(firstNumber, secondNumber);
                Notify("FirstNumber");
            }
        }
        public int SecondNumber
        {
            get { return secondNumber; }
            set
            {
                secondNumber = value;
                Sum = model.summa(firstNumber, secondNumber);
                Notify("SecondNumber");
            }
        }
        public SolidColorBrush ColorBrush
        {
            get { return colorBrush; }
            set
            {
                colorBrush = value;
                Notify("ColorBrush");
            }
        }

        public byte R
        {
            get { return r; }
            set
            {
                r = value;
                ColorBrush = new SolidColorBrush(Color.FromRgb(r, g, b));
                Notify("R");
            }
        }
        public byte G
        {
            get { return g; }
            set
            {
                g = value;
                ColorBrush = new SolidColorBrush(Color.FromRgb(r, g, b));
                Notify("G");
            }
        }
        public byte B
        {
            get { return b; }
            set
            {
                b = value;
                ColorBrush = new SolidColorBrush(Color.FromRgb(r, g, b));
                Notify("B");
            }
        }
        public ViewModel2()
        {
            model = new Sum();
        }
    }
}
