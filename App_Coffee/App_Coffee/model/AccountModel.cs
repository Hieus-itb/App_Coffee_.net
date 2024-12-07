using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Coffee.model
{
    namespace App_Coffee.model
    {
        internal class AccountModel
        {
            public static string LoggedInUsername { get; private set; }

            public string Username { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }

            public AccountModel(string username, string password, string role)
            {
                Username = username;
                Password = password;
                Role = role;
            }

            public static void SetLoggedInUser(string username)
            {
                LoggedInUsername = username;
            }
        }
    }


}
