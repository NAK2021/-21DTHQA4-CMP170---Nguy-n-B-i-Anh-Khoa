using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class User
    {
        private Dictionary<string, string> protected_password;
        public User(string password, string hash_password) { 
            protected_password = new Dictionary<string, string>();
            protected_password[hash_password] = password;
        }
        public string CheckAccout(string hash_password)
        {
            if (protected_password.ContainsKey(hash_password)) { return protected_password[hash_password]; }
            return "";
        }
    }
}
