using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
{
    class RecordModel
    {
        List<Record> records;
        public List<Record> GetRecords()
        {
            records = new List<Record>();
            MySqlConnection connection = new MySqlConnection
                ("Server=localhost;Database=telephonebook_contacts;Uid=root;Pwd=root");
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM contacts", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for(int i =0; i < table.Rows.Count; i++)
            {
                records.Add(new Record()
                {
                    Id = (int)table.Rows[i].ItemArray[0],
                    Name = table.Rows[i].ItemArray[1].ToString(),
                    Phone = table.Rows[i].ItemArray[2].ToString(),
                    BDay = table.Rows[i].ItemArray[3].ToString(),
                    ImageUri = table.Rows[i].ItemArray[4].ToString(),
                    Note = table.Rows[i].ItemArray[5].ToString()
                });
            }
            return records;
        }
    }
}
