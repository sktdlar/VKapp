using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;

namespace VKapp
{
    

    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public User(string login, string password, string name)
        {
            Login = login;
            Password = password;
            Name = name;
        }
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            return users;
        }
        
    }
}
