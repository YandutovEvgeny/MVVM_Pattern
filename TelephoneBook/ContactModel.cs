using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TelephoneBook
{
    class ContactModel
    {
        public Contact GetContact(string login, string password)
        {
            Contact contact = new Contact();
            string connectString = "Server=localhost;Database=testdb;Uid=root;Pwd=root";
            MySqlConnection mySqlConnection = new MySqlConnection(connectString);
            mySqlConnection.Open();
            string query = $"SELECT * FROM users WHERE login = '{login}' AND pass = '{password}'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, mySqlConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                contact.Id = (int)table.Rows[0].ItemArray[0];
                contact.Login = table.Rows[0].ItemArray[1].ToString();
                contact.Password = table.Rows[0].ItemArray[2].ToString();
                contact.Date = table.Rows[0].ItemArray[3].ToString(); 
            }
            mySqlConnection.Close();
            return contact;
        }
    }
}
