using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAT602_MIlestone_Three
{
    public class DatabaseConnection
    {
        private string _connectionString;
        public string ConnectionString { get => _connectionString; set => _connectionString = value; }

        // ConnectionString = "Server=localhost:3306;Database=TreasureHuntAdventure;User Id=root;Password=P@ssword1;";
        
        // Constructor
        public DatabaseConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
            
        }

        // MySqlConnection is a class in the MySql.Data.MySqlClient namespace,
        // used to connect to a MySQL database.
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }        
    }

}
