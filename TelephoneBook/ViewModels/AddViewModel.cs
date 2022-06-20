using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TelephoneBook
{
    class AddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        DataBaseModel recordModel;
        Record record;
        public Action CloseAction { get; set; }

        public AddViewModel()
        {
            recordModel = new DataBaseModel();
            record = new Record();
        }

        public ICommand AddRecordButton
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    if (recordModel.GetAllRecords().Count >= 1)
                        record.Id = recordModel.GetAllRecords()[recordModel.GetAllRecords().Count - 1].Id;
                    else
                        record.Id = 0;
                    record.Id += 1;
                    recordModel.AddRecord(record);
                    MessageBox.Show("Контакт добавлен!");
                    CloseAction();
                }));
            }
        }


        public Record AddRecord
        {
            get { return record; }
            set
            {
                record = value;
                Notify("AddRecord");
            }
        }

    }
}
