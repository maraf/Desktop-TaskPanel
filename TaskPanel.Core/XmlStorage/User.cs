using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCore;
using TaskPanel.Core.Domain;

namespace TaskPanel.Core.XmlStorage
{
    public class User : NotifyPropertyChanged, IUser
    {
        private int id;
        private string userName;
        private string password;
        private string firstName;
        private string lastName;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                FirePropertyChanged("ID");
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                FirePropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                FirePropertyChanged("Password");
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                FirePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                FirePropertyChanged("LastName");
            }
        }
    }
}
