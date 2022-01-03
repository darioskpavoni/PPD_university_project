using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect
{
    public class CurrentAccount
    {
        private string name;
        private string surname;
        private string email;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }


        public CurrentAccount(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

    }
}