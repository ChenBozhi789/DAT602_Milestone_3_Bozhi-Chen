using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_MIlestone_Three
{
    internal class Player
    {
        private static string _username;
        private static string _email;
        private static string _password;
        private static int _row;
        private static int _column;

        public static string Username { get => _username; set => _username = value; }
        public static string Email { get => _email; set => _email = value; }
        public static string Password { get => _password; set => _password = value; }
        public static int Row { get => _row; set => _row = value; }
        public static int Column { get => _column; set => _column = value; }
    }
}
