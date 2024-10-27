using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_MIlestone_Three
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int LockState { get; set; }
        public int LoginState { get; set; }
        public int GameState { get; set; }
        public int IsAdministrator { get; set; }
        public string Attempt { get; set; }
    }
}
