using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TelephoneBook
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Contact contact;
        ContactModel model;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ViewModel()
        {
            contact = new Contact();
            model = new ContactModel();
        }
        public ICommand EnterButton
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    Contact contact1 = model.GetContact(Login, Password);
                    if (contact1.Login == Login && contact1.Password == Password)
                        MessageBox.Show("Данные получены, обрабатывается получение данных...");
                    else
                        MessageBox.Show("Нет такой записи");
                }));
            }
        }

        public string Login
        {
            get { return contact.Login; }
            set
            {
                contact.Login = value;
                Notify("Login");
            }
        }
        public string Password
        {
            get { return contact.Password; }
            set
            {
                contact.Password = value;
                Notify("Password");
            }
        }
    }
}
