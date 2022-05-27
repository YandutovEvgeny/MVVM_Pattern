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
        Contact contact;
        //TODO GET ADD
        public ContactModel()
        {
            contact = new Contact();
        }
        public void GetContact(string login, string password)
        {
            string connectString = "Server=localhost;Database=testdb;Uid=root;Pwd=root";
            MySqlConnection mySqlConnection = new MySqlConnection(connectString);
            mySqlConnection.Open();
            string query = $"SELECT * FROM users WHERE login = '{contact.Login}' AND pass = '{contact.Password}'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, mySqlConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                MessageBox.Show("У вас есть доступ на страницу");
            }
            else
            {
                MessageBox.Show("Нет такой записи");
            }
            mySqlConnection.Close();
        }
    }
}
