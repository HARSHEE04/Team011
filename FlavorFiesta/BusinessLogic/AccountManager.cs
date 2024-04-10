﻿using System;
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

        public void AddUser(User user)
        {
            foreach (string key in _users.Keys)
            {
                if (key == user.Email)
                    throw new Exception("This user already exists");

            }

            Dictionary<string, User> dict = new Dictionary<string, User>();
            dict.Add(user.Email, user);
           
        }

        public void RemoveUser(User user)
        {
            foreach (string email in _users.Keys)
            {
                if (email == user.Email)
                    Users.Remove(user.Email);
            }
        }

        public bool SearchUser(User user)
        {
            foreach (string email in _users.Keys)
            {
                if (email == user.Email)
                    return true;
            }
            return false;
        }

        

    }
}
