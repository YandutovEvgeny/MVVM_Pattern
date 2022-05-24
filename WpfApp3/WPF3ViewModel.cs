using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp3
{
    class WPF3ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        List<Item> _items;
        Item _item;

        public WPF3ViewModel()
        {
            _items = new List<Item>()
            {
                new Item(){Color = new System.Windows.Media.SolidColorBrush(Color.FromRgb(255,0,0)), Name = "Красный"},
                new Item(){Color = new System.Windows.Media.SolidColorBrush(Color.FromRgb(0,255,0)), Name = "Зелёный"},
                new Item(){Color = new System.Windows.Media.SolidColorBrush(Color.FromRgb(0,0,255)), Name = "Синий"}
            };
        }
        public List<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                Notify("Items");
            }
        }
        public Item SelectedItem
        {
            get { return _item; }
            set
            {
                _item = value;
                Notify("SelectedItem");
            }
        }
        public ICommand ShowColor
        {
            get {
                return new ButtonCommand(new Action(() =>
                {
                    if(_item != null)
                    {
                        MessageBox.Show($"Вы нажали на {_item.Name} цвет");
                    }
                }));
            }
        }
    }
}
