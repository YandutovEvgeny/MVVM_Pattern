using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace NotesApp
{
    class DataBaseModel : INotesModel
    {
        MySqlConnection _connection;
        List<Note> _notes;
        public DataBaseModel()
        {
            _connection = new MySqlConnection
                ("Server=localhost;Database=testdb;Uid=root;Pwd=root");
            _notes = new List<Note>();
        }
        void ExecuteCommand(string query)
        {
            MySqlCommand command = new MySqlCommand(query, _connection);
            _connection.Open();
            command.ExecuteNonQuery();  //Выполнение команды без return(responce)
            _connection.Close();
        }
        public void AddNote(Note note)
        {
            string query = "INSERT INTO notes (header, text, imageuri, deadline)"
                + $"VALUES ('{note.Header}', '{note.Text}', '{note.ImageUri}', '{note.DeadLine:yyyy-MM-dd}')";
            ExecuteCommand(query);
        }

        public void DeleteNote(Note note)
        {
            string query = "DELETE FROM notes WHERE id=" + note.Id.ToString();
            ExecuteCommand(query);
        }

        public List<Note> GetActualNotes()
        {
            _notes = new List<Note>();
            MySqlDataAdapter adapter = new MySqlDataAdapter
                ("SELECt * FROM notes WHERE Deadline <= CURRENT_DATE()", _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                _notes.Add(new Note()
                {
                    Id = (int)table.Rows[i].ItemArray[0],
                    Header = table.Rows[i].ItemArray[1].ToString(),
                    Text = table.Rows[i].ItemArray[2].ToString(),
                    ImageUri = table.Rows[i].ItemArray[3].ToString(),
                    DeadLine = DateTime.Parse(table.Rows[i].ItemArray[4].ToString())
                });
            }
            return _notes;
        }

        public List<Note> GetAllNotes()
        {
            _notes = new List<Note>();
            MySqlDataAdapter adapter = new MySqlDataAdapter
                ("SELECt * FROM notes", _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for(int i = 0; i < table.Rows.Count; i++)
            {
                _notes.Add(new Note()
                {
                    Id = (int)table.Rows[i].ItemArray[0],
                    Header = table.Rows[i].ItemArray[1].ToString(),
                    Text = table.Rows[i].ItemArray[2].ToString(),
                    ImageUri = table.Rows[i].ItemArray[3].ToString(),
                    DeadLine = DateTime.Parse(table.Rows[i].ItemArray[4].ToString())
                });
            }
            return _notes;
        }

        public Note GetNote(int id)
        {
            string query = $"SELECt * FROM notes WHERE id = {id}";
            Note note = new Note();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                note.Id = (int)table.Rows[0].ItemArray[0];
                note.Header = table.Rows[0].ItemArray[1].ToString();
                note.Text = table.Rows[0].ItemArray[2].ToString();
                note.ImageUri = table.Rows[0].ItemArray[3].ToString();
                note.DeadLine = DateTime.Parse(table.Rows[0].ItemArray[4].ToString()); 
            }
            return note;
        }

        public void UpdateNote(Note note, Note result)
        {
            string query = $"UPDATE notes SET header='{result.Header}', text='{result.Text}'," +
                $"imageuri='{result.ImageUri}', deadline='{result.DeadLine:yyyy-MM-dd}' WHERE id={note.Id}";
            ExecuteCommand(query);
        }
    }
}
