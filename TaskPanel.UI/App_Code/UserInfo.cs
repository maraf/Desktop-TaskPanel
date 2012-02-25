using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCore;

namespace TaskPanel.UI
{
    public class UserInfo : NotifyPropertyChanged
    {
        private string userName;
        private string password;
        private string file;

        private bool autoLogin;
        private bool savePassword;

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

        public string File
        {
            get { return file; }
            set
            {
                file = value;
                FirePropertyChanged("File");
            }
        }

        public bool AutoLogin
        {
            get { return autoLogin; }
            set
            {
                autoLogin = value;
                FirePropertyChanged("AutoLogin");
            }
        }

        public bool SavePassword
        {
            get { return savePassword; }
            set
            {
                savePassword = value;
                FirePropertyChanged("SavePassword");
            }
        }

        public bool IsSet()
        {
            return !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(File);
        }
    }
}
