using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorFiesta.BusinessLogic
{
    public class User
    {
        string _name;
        string _email;
        string _password;
        DateTime _dateOfBirth;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name cannot be blank.");
                _name = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email cannot be blank.");
                }
                _email = value;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Password cannot be blank.");
                else if (value.Length < 6)
                    throw new Exception("Password must contain more than 6 characters.");
                _password = value;
            }
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (value == DateTime.Today)
                    throw new Exception("Date of birth must be greater than today's date.");
                _dateOfBirth = value;
            }
        }

        public User(string name, string email, string password, DateTime dateOfBirth)
        {

            Name = name;
            Email = email;
            Password = password;
            DateOfBirth = dateOfBirth;
        }

        
    }
}
