using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace DAT602_MIlestone_Three
{
    public class UserDAO
    {
        // Connection string to the MySQL database
        // IMPORTANT: Please modify the "Pwd" part to match your database password. Thank you
        private string connectionString = "Server=localhost; Port=3306; Database=TreasureHuntAdventure; Uid=root; Pwd=P@ssword1;";

        // 1. Player login, including lock out. [4]
        public int Login(string email, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL login(@Email, @Password);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Return result message
                                string resultMessage = reader.GetString(0);

                                if (resultMessage == "You have Logged in successfully")
                                {
                                    return 1;
                                }
                                else if (resultMessage == "Invalid credentials! Attempt + 1")
                                {
                                    return 0;
                                }
                                else if (resultMessage == "Invalid credentials! Account has been locked out")
                                {
                                    return -1;
                                }
                                else if (resultMessage == "This account does not exist")
                                {
                                    return -2;
                                }
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }

        // 2. Player registration
        public bool Register(Player Player)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Call procedure rather than query
                    string query = "CALL register(@Username, @Email, @Password);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to the query
                        // These codes from https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparametercollection.addwithvalue?view=netframework-4.8.1
                        cmd.Parameters.AddWithValue("@Username", Player.Username);
                        cmd.Parameters.AddWithValue("@Email", Player.Email);
                        cmd.Parameters.AddWithValue("@Password", Player.Password);
                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Return result message
                                string message = reader.GetString(0);

                                if (message == "Register successfully")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // 3. Laying out tiles on a game board.
        public bool Laying_out_tiles(Map map)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL make_a_board(@MaxRow, @MaxCol);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaxRow", map.MaxRow);
                        cmd.Parameters.AddWithValue("@MaxCol", map.MaxColumn);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Return result message
                                string message = reader.GetString(0);

                                if (message == "Create game board successfully")
                                {
                                    // CLose the previous opened reader. Otherwise, it will cause an error
                                    reader.Close();

                                    // Add player to the game
                                    string addPlayerCmd = "CALL add_player_to_game(@GameID, @PlayerID, @TileID);";
                                    using (MySqlCommand executeAddPlayer = new MySqlCommand(addPlayerCmd, conn))
                                    {
                                        executeAddPlayer.Parameters.AddWithValue("@GameID", GetCurrentGameID());
                                        executeAddPlayer.Parameters.AddWithValue("@PlayerID", GetCurrentPlayerID());
                                        executeAddPlayer.Parameters.AddWithValue("@TileID", 1);
                                        executeAddPlayer.ExecuteNonQuery();
                                    }

                                    int targetMapID = GetCurrentMapID();
                                    bool addItemResult = Placing_an_item_on_a_tile(targetMapID);
                                    return addItemResult;
                                }
                                // If the message is not "Create game board successfully", then return false
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // 4. Placing an item on a tile. [4]
        public bool Placing_an_item_on_a_tile(int MapID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL placing_item_on_tile(@MapID);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MapID", MapID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Return result message
                                string message = reader.GetString(0);

                                if (message == "Assign item on tile successfully")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // 5. Player game play movement
        public bool Player_game_play_movement(int GameID, int PlayerID, int TargetTile)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL player_movement(@GameID, @PlayerID, @TargetTile);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GameID", GameID);
                        cmd.Parameters.AddWithValue("@PlayerID", PlayerID);
                        cmd.Parameters.AddWithValue("@TargetTile", TargetTile);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // If returns at least one record, then return true, otherwise return false
                            if (reader.Read())
                            {
                                // Return result message
                                string message = reader.GetString(0);

                                if (message == "Player movement successfully")
                                {
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Illegal Tile!");
                                    return false;
                                }
                            } 
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // 6. Game play scoring.[4]
        public int Game_play_scoring(int GameID, int PlayerID, int TargetTile)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL game_play_scoring(@GameID, @PlayerID, @TargetTile);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GameID", GameID);
                        cmd.Parameters.AddWithValue("@PlayerID", PlayerID);
                        cmd.Parameters.AddWithValue("@TargetTile", TargetTile);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string resultMessage = reader.GetString(0);

                                // Return type of current item
                                if (resultMessage == "You get the Diamond! Score + 10")
                                {
                                    return 1;
                                }
                                else if (resultMessage == "You get the Bomb! Score - 5")
                                {
                                    return 2;
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
        }

        // 7. Player game play acquiring inventory
        public int Add_item_to_inventory(int GameID, int PlayerID, int TargetTile)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL acquire_item_to_inventory(@GameID, @PlayerID, @TargetTile);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GameID", GameID);
                        cmd.Parameters.AddWithValue("@PlayerID", PlayerID);
                        cmd.Parameters.AddWithValue("@TargetTile", TargetTile);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string resultMessage = reader.GetString(0);

                                // Return type of current item
                                if (resultMessage == "Diamond has been stored in inventory" || resultMessage == "Diamond stock + 1")
                                {
                                    return 1;
                                }
                                else if (resultMessage == "Bomb has been stored in inventory" || resultMessage == "Bomb stock + 1")
                                {
                                    return 2;
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                return -1;
                            }
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }

        // 8. Move an Item (NPC effect)
        public bool move_an_item(int MapID, int startingtileID, int targetTileID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL move_an_item(@MapID, @StartingtileID, @TargetTileID);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MapID", 1);
                        cmd.Parameters.AddWithValue("@StartingtileID", startingtileID);
                        cmd.Parameters.AddWithValue("@TargetTileID", targetTileID);

                        using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string moveResult = reader.GetString(0);
                                return moveResult == "Move item successfully";
                            }
                            else
                            {
                                return false;
                            }
                        }                     
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        // 9. Kill running games
        public bool KillRunningGame(int gameID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Call the stored procedure
                    string query = "CALL kill_running_game(@pGameID);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pGameID", gameID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Return result message
                                string message = reader.GetString(0);

                                if (message == "Kill running game successfully")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // 10. Add new players
        public bool AddPlayer(Player player)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Call procedure rather than query
                    string query = "CALL add_player(@Username, @Email, @Password, @LockState, @IsAdministrator);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to the query
                        // These codes from https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparametercollection.addwithvalue?view=netframework-4.8.1
                        cmd.Parameters.AddWithValue("@Username", player.Username);
                        cmd.Parameters.AddWithValue("@Email", player.Email);
                        cmd.Parameters.AddWithValue("@Password", player.Password);
                        cmd.Parameters.AddWithValue("@LockState", player.LockState);
                        cmd.Parameters.AddWithValue("@IsAdministrator", player.IsAdministrator);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Return result message
                                string message = reader.GetString(0);

                                if (message == "Player added successfully")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // 11. Update data of a player
        public bool UpdatePlayer(Player player)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL update_player(@Email, @pUsername , @pPassword, @pLockState, @pIsAdministrator);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", player.Email);
                        cmd.Parameters.AddWithValue("@pUsername", player.Username);                        
                        cmd.Parameters.AddWithValue("@pPassword", player.Password);
                        cmd.Parameters.AddWithValue("@pLockState", player.LockState);
                        cmd.Parameters.AddWithValue("@pIsAdministrator", player.IsAdministrator);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Return result message
                                string message = reader.GetString(0);

                                if (message == "Player edited successfully")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        // 12. Delete a player
        public bool DeletePlayer(Player player)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL delete_player(@Email);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to the query
                        // These codes from https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparametercollection.addwithvalue?view=netframework-4.8.1
                        cmd.Parameters.AddWithValue("@Email", player.Email);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Return result message
                                string message = reader.GetString(0);

                                if (message == "Delete player successfully")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // This method is used to get the last insert MapID
        public int GetCurrentGameID()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT GameID FROM tb_Game ORDER BY GameID DESC LIMIT 1;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        // This method is used to get the last insert MapID
        public int GetCurrentMapID()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MapID FROM tb_Map ORDER BY MapID DESC LIMIT 1;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        // This method is used to get the last insert MapID
        public int GetCurrentPlayerID()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT PlayerID FROM tb_Player ORDER BY PlayerID DESC LIMIT 1;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public int GetCurrentTileID(int TileRow, int TileCol)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TileID FROM tb_Tile WHERE TileRow = @TileRow and TileCol = @TileCol;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TileRow", TileRow);
                        cmd.Parameters.AddWithValue("@TileCol", TileCol);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32("TileID");
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        // Getting data from tb_tile and used to create game board
        public List<Tile> GetTiles()
        {
            List<Tile> tiles = new List<Tile>();            

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query =
                        @"SELECT t.TileID, t.TileRow, t.TileCol, t.IsEmptied, t.IsOccupied, COALESCE(tb_Item.ItemTypeID, 0) AS ItemTypeID
                        FROM tb_Tile t
                        LEFT JOIN tb_Tile_Item ON t.TileID = tb_Tile_Item.TileID
                        LEFT JOIN tb_Item ON tb_Tile_Item.ItemID = tb_Item.ItemID
                        WHERE t.MapID = @MapID;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MapID", GetCurrentMapID());

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read the data from tb_tile
                            while (reader.Read())
                            {
                                Tile tile = new Tile
                                {
                                    TileID = reader.GetInt32("TileID"),
                                    TileRow = reader.GetInt32("TileRow"),
                                    TileCol = reader.GetInt32("TileCol"),
                                    IsEmptied = reader.GetBoolean("IsEmptied"),
                                    IsOccupied = reader.GetBoolean("IsOccupied"),
                                    ItemTypeID = reader.GetInt32("ItemTypeID")
                                };
                                // Store data in the list
                                tiles.Add(tile);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return tiles;
        }
    }
}
