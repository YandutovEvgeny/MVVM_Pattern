using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TelephoneBook.Views
{
    /// <summary>
    /// Interaction logic for UpdateRecord.xaml
    /// </summary>
    public partial class UpdateRecord : Window
    {
        public UpdateRecord()
        {
            InitializeComponent();
            UpdateViewModel updateViewModel = new UpdateViewModel();
            DataContext = updateViewModel;
            if (updateViewModel.CloseAction == null)
                updateViewModel.CloseAction = new Action(Close);
        }
    }
}
