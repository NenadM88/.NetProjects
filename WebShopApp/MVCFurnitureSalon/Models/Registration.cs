using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFurnitureSalon.Models
{
    public class Registration
    {
        private string userName;
        private string password;
        private string name;
        private string lastName;
        private string role;
        private string number;
        private string email;

        //Property
        [Required]
        [DataType(DataType.Text)]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        [Required]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [Required]
        [DataType(DataType.Text)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Required]
        [DataType(DataType.Text)]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [Required]
        [DataType(DataType.Text)]
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}