using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorFiesta.BusinessLogic
{
    public class AccountsManager
    {
        Dictionary<string, User> _users = new Dictionary<string, User>();

        public Dictionary<string, User> Users => _users;

        public void SetUsers(Dictionary<string, User> users)
        {
            _users = users ?? throw new ArgumentNullException(nameof(users));
        }

        public void AddUser(User user)
        {
            if (_users.ContainsKey(user.Email))
                throw new Exception("This user already exists");
            _users[user.Email] = user;
        }

        public bool SearchUser(string emailEntry)
        {
            foreach (string email in _users.Keys)
            {
                if (email == emailEntry)
                    return true;
            }
            return false;
        }

        public bool SearchPassword(string passwordEntry)
        {
            foreach (string email in _users.Keys)
            {
                if (_users[email].Password == passwordEntry)
                    return true;
            }
            return false;
        }
    }
}
