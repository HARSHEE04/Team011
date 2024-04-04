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
        Random _random;

        public string Name
        {
            get => Name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name cannot be blank.");
                Name = value;
            }
        }

        public string Email
        {
            get => Email;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email cannot be blank.");
                }
                Email = value;
            }
        }

        public string Password
        {
            get => Password;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Password cannot be blank.");
                else if (value.Length < 6)
                    throw new Exception("Password must contain more than 6 characters.");
                Password = value;
            }
        }

        public DateTime DateOfBirth
        {
            get => DateOfBirth;
            set
            {
                if (value == DateTime.Today)
                    throw new Exception("Date of birth must be greater than today's date.");
                DateOfBirth = value;
            }
        }
    }
}
