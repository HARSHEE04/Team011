using FlavorFiesta.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlavorFiesta.DataPersistance
{
    public class AccountManagerDataPersistance
    {
        string _filepath;

        public AccountManagerDataPersistance(string filepath)
        {
            _filepath = filepath;
        }
        public void SavePersonObjects(Dictionary<string, User> users)

        {
            using (FileStream writer = new FileStream(_filepath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                JsonSerializer.Serialize(writer, users);
            }
        }

        public Dictionary<string, User> ReadPersonObjects()
        {
            Dictionary<string, User> users = new Dictionary<string, User>();

            using (FileStream reader = new FileStream(_filepath, FileMode.Open, FileAccess.Read))
            {
                users = JsonSerializer.Deserialize<Dictionary<string, User>>(reader);
            }
            return users;
        }
    }
}
