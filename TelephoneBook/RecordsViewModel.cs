using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TelephoneBook
{
    class RecordsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        List<Record> names;
        Record record;
        IRecordsModel baseModel;

        public RecordsViewModel()
        {
            record = new Record();
            baseModel = new DataBaseModel();
            if (baseModel.GetAllRecords() != null)
            {
                names = new List<Record>(baseModel.GetAllRecords());
            }
            else
            {
                names = new List<Record>();
            }
        }
        public List<Record> Names
        {
            get { return names; }
            set
            {
                names = value;
                Notify("Names");
            }
        }
        public Record SelectedRecord
        {
            get { return record; }
            set
            {
                record = value;
                Notify("SelectedRecord");
            }
        }
        public ICommand AddRecord
        {
            get 
            {
                return new ButtonCommand(new Action(() =>
                {
                    AddRecord addRecord = new AddRecord();
                    addRecord.ShowDialog();
                    Names = new List<Record>(baseModel.GetAllRecords());
                }));
            }
        }
        public ICommand DeleteRecord
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    if(record != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить контакт?",
                            "Удаление контакта " + record.Name, MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                            baseModel.DeleteRecord(record);
                        Names = new List<Record>(baseModel.GetAllRecords());
                    }
                }));
            }
        }
        public ICommand UpdateRecord
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    if (record != null)
                    {
                        UpdateViewModel.Id = record.Id;
                        UpdateRecord updateRecord = new UpdateRecord();
                        updateRecord.ShowDialog();
                        Names = new List<Record>(baseModel.GetAllRecords());
                    }
                }));
            }
        }
    }
}
