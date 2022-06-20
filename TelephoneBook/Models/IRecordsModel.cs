using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
{
    interface IRecordsModel
    {
        List<Record> GetAllRecords();
        Record GetRecord(int id);
        void AddRecord(Record record);
        void DeleteRecord(Record record);
        void UpdateRecord(Record record, Record result);
    }
}
