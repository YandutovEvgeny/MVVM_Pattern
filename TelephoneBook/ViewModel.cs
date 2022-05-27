using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TelephoneBook
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ContactModel contactModel;
        Contact contact;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ViewModel()
        {
            contactModel = new ContactModel();
            contact = new Contact();
        }
        public ICommand EnterButton
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    contactModel.GetContact(Login, Password);
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
