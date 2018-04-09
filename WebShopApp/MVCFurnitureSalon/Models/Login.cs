using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFurnitureSalon.Models
{
    public class Login
    {

        private string userName;
        private string password;

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
    }
}