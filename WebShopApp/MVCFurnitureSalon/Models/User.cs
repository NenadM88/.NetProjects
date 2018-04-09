using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFurnitureSalon.Models
{
    public class User
    {
        private string userName;
        private string password;
        private string name;
        private string lastName;
        private string role;
        private string number;
        private string email;

        //Property
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}