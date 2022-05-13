using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    class ViewModel : INotifyPropertyChanged  //Интрефейс нужен, чтобы оповещать нашу форму, о том, что что-то поменялось
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Model Model;
        string text;
        string text2;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                Text2 = Model.Reverse(text);
                //if(PropertyChanged != null)
                //Метод, который даст оповещение о том, что переменная изменилась
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
        }
        public string Text2
        {
            get { return text2; }
            set
            {
                text2 = value;
                //if(PropertyChanged != null)
                //Метод, который даст оповещение о том, что переменная изменилась
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text2"));
            }
        }

        public ViewModel()
        {
            Model = new Model();
            Text = "привет мир!";
        }
    }
}
