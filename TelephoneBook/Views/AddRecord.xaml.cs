using System;
using System.Windows;

namespace TelephoneBook.Views
{
    /// <summary>
    /// Interaction logic for AddRecord.xaml
    /// </summary>
    public partial class AddRecord : Window
    {
        public AddRecord()
        {
            InitializeComponent();
            AddViewModel addViewModel = new AddViewModel();
            DataContext = addViewModel;
            if (addViewModel.CloseAction == null)
                addViewModel.CloseAction = new Action(Close);
        }
    }
}
