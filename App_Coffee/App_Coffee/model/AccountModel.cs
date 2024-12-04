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
            // Thuộc tính lưu tên người dùng đã đăng nhập
            public static string LoggedInUsername { get; private set; }

            public string Username { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }

            // Constructor
            public AccountModel(string username, string password, string role)
            {
                Username = username;
                Password = password;
                Role = role;
            }

            // Phương thức để cập nhật tên người dùng đã đăng nhập
            public static void SetLoggedInUser(string username)
            {
                LoggedInUsername = username;
            }
        }
    }


}
