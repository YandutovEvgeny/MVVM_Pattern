using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        RecordModel recordModel;

        public RecordsViewModel()
        {
            record = new Record();
            recordModel = new RecordModel();
            if (recordModel.GetRecords() != null)
            {
                names = new List<Record>(recordModel.GetRecords());
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
    }
}
