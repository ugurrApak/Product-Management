using Product_Management.AbstractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management.Models
{
    internal class User:CommonProp
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string name, string surname, string email, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            IsStatus= true;
        }
    }
}
