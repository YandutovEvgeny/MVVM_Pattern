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

        List<Record> records;
        RecordModel recordModel;

        public RecordsViewModel()
        {
            recordModel = new RecordModel();
            if (recordModel.GetRecords() != null)
                records = new List<Record>(recordModel.GetRecords());
            else
                records = new List<Record>();
        }

        public List<Record> Records
        {
            get { return records; }
            set
            {
                records = value;
                Notify("Records");
            }
        }
    }
}
