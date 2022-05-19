using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TikTakToe
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Специальный список(List) для паттерна MVVM
        //Используется для отображения строк в content button
        ObservableCollection<string> _buttonsText;
        TikTakToeModel model;
        public ViewModel()
        {
            model = new TikTakToeModel();
            _buttonsText = new ObservableCollection<string>()
                { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        }

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<string> ButtonText
        {
            get { return _buttonsText; }
            set
            {
                _buttonsText = value;
                Notify("ButtonText");
            }
        }

        public ICommand AboutClick
        {
            get
            {
                return new ButtonCommand(new Action<object>((parameter) =>
                { 
                    {
                        About form = new About();
                        form.ShowDialog();
                    }
                }));
            }
        }

        public ICommand ButtonClick     //Нажатие на кнопку для нолика или крестика
        {
            get
            {
                return new ButtonCommand(new Action<object>((parameter) =>
                {
                    int index = Convert.ToInt32(parameter.ToString());
                    ButtonText[index] = model.PlayTurn(index);
                    if(model.CheckWinner() != null)
                    {
                        MessageBox.Show(model.CheckWinner());
                    }
                }));
            }
        }
        
        public ICommand NewGame     //Нажатие на кнопку "новая игра"
        {
            get 
            {
                return new ButtonCommand(new Action<object>((parameter) =>
                {
                    model = new TikTakToeModel();
                    ButtonText = new ObservableCollection<string>()
                        { " ", " ", " ", " ", " ", " ", " ", " ", " " };
                }));
            }
        }
    }
}
