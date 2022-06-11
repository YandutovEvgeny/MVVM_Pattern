using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
{
    class DataBaseModel : IRecordsModel
    {
        MySqlConnection connection;
        List<Record> records;

        public DataBaseModel()
        {
            connection = new MySqlConnection
                ("Server=localhost;Database=telephonebook_contacts;Uid=root;Pwd=root");
            records = new List<Record>();
        }
        void ExecuteCommand(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AddRecord(Record record)
        {
            string query = "INSERT INTO contacts (name, phone, birthday, image, note)"
                + $"VALUES ('{record.Name}', '{record.Phone}', '{record.BDay}', '{record.ImageUri}'," +
                $"'{record.Note}')";
            ExecuteCommand(query);
        }

        public void DeleteRecord(Record record)
        {
            string query = "DELETE FROM contacts WHERE id=" + record.Id.ToString();
            ExecuteCommand(query);
        }

        public List<Record> GetAllRecords()
        {
            records = new List<Record>();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM contacts", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
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

        public Record GetRecord(int id)
        {
            string query = $"SELECT * FROM contacts WHERE id = {id}";
            Record record = new Record();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                record.Id = (int)table.Rows[0].ItemArray[0];
                record.Name = table.Rows[0].ItemArray[1].ToString();
                record.Phone = table.Rows[0].ItemArray[2].ToString();
                record.BDay = table.Rows[0].ItemArray[3].ToString();
                record.ImageUri = table.Rows[0].ItemArray[4].ToString();
                record.Note = table.Rows[0].ItemArray[5].ToString();
            }
            return record;
        }

        public void UpdateRecord(Record record, Record result)
        {
            string query = $"UPDATE contacts SET name='{result.Name}', phone='{result.Phone}'," +
                $"birthday='{result.BDay}', image='{result.ImageUri}', note='{result.Note}' WHERE" +
                $"id={record.Id}";
            ExecuteCommand(query);
        }
    }
}
