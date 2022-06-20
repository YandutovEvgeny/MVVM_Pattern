using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TelephoneBook
{
    class UpdateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static int Id;
        DataBaseModel baseModel;
        Record firstRecord, secondRecord;
        public Action CloseAction { get; set; }

        public UpdateViewModel()
        {
            baseModel = new DataBaseModel();
            firstRecord = baseModel.GetRecord(Id);
            secondRecord = new Record()
            {   
                Id = firstRecord.Id,
                Name = firstRecord.Name,
                Phone = firstRecord.Phone,
                BDay = firstRecord.BDay,
                ImageUri = firstRecord.ImageUri,
                Note = firstRecord.Note
            };
        }

        public Record UpdateRecord
        {
            get { return secondRecord; }
            set
            {
                secondRecord = value;
                Notify("UpdateRecord");
            }
        }
        public ICommand UpdateRecordButton
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    baseModel.UpdateRecord(firstRecord, secondRecord);
                    MessageBox.Show("Изменено!");
                    CloseAction();
                }));
            }
        }
    }
}
