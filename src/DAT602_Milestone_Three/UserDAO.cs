using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602_MIlestone_Three
{
    public class UserDAO
    {
        // Connection string to the MySQL database
        // IMPORTANT: Please modify the "Pwd" part to match your database password. Thank you
        private string connectionString = "Server=localhost; Port=3306; Database=DAT602m2t2db; Uid=root; Pwd=P@ssword1;";

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
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        // Return the first column of the first row in the result set
                        object result = cmd.ExecuteScalar();

                        // If result is not null, then return the result, otherwise return 0
                        if (result != null)
                        {
                            int currentUserID = Convert.ToInt32(result);
                            GlobalVariable.UserID = currentUserID;
                            return currentUserID;
                        }
                        else
                        {
                            return 0;
                        }
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
        public bool Register(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Call procedure rather than query
                    string query = "CALL registration(@Username, @Email, @Password);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to the query
                        // These codes from https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparametercollection.addwithvalue?view=netframework-4.8.1
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        
                        int result = cmd.ExecuteNonQuery();
                        Console.WriteLine("You have logged successfully");
                        // Check if the query was successful
                        return result > 0;
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
        public int Laying_out_tiles(Map map)
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
                        cmd.ExecuteNonQuery();
                    }

                    // Getting MapID from the last inserted record
                    string getLastInsertGameID = "SELECT GameID FROM tb_Game ORDER BY GameID DESC LIMIT 1;";
                    using (MySqlCommand cmd = new MySqlCommand(getLastInsertGameID, conn))
                    {
                        object GameID = cmd.ExecuteScalar();
                        // If MapID is not null, then return true, otherwise return false
                        if (GameID != null)
                        {
                            int lastGameID = Convert.ToInt32(GameID);
                            GlobalVariable.GameID = lastGameID;
                        }
                        else
                        {
                            MessageBox.Show("Failed to retrieve GameID.");  
                            return 0;
                        }
                    }

                    // Getting MapID from the last inserted record
                    string getLastInsertMapID = "SELECT MapID FROM tb_Map ORDER BY MapID DESC LIMIT 1;";
                    using (MySqlCommand cmd = new MySqlCommand(getLastInsertMapID, conn))
                    {
                        object MapID = cmd.ExecuteScalar();
                        // If MapID is not null, then return true, otherwise return false
                        if (MapID != null)
                        {
                            int lastGameID = Convert.ToInt32(MapID);
                            GlobalVariable.MapID = lastGameID;
                        }
                        else
                        {
                            MessageBox.Show("Failed to retrieve MapID.");
                            return 0;
                        }
                    }

                    // Getting UserID from the last inserted record
                    string getLastInsertUserID = "SELECT UserID FROM tb_user ORDER BY UserID DESC LIMIT 1;";
                    using (MySqlCommand cmd = new MySqlCommand(getLastInsertUserID, conn))
                    {
                        object UserID = cmd.ExecuteScalar();
                        // If MapID is not null, then return true, otherwise return false
                        if (UserID != null)
                        {
                            int lastUserID = Convert.ToInt32(UserID);
                            GlobalVariable.UserID = lastUserID;
                        }
                        else
                        {
                            MessageBox.Show("Failed to retrieve UserID.");
                            return 0;
                        }
                    }

                    // Add player to the game
                    string queryTwo = "CALL add_player_to_game(@GameID, @UserID, @TileID);";
                    using (MySqlCommand cmd = new MySqlCommand(queryTwo, conn))
                    {
                        cmd.Parameters.AddWithValue("@GameID", GlobalVariable.GameID);
                        cmd.Parameters.AddWithValue("@UserID", GlobalVariable.UserID);
                        cmd.Parameters.AddWithValue("@TileID", 1);
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        // 4. Placing an item on a tile. [4]
        public bool Placing_an_item_on_a_tile(Map map)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL placing_item_on_tile(@MapID);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MapID", map.MapID);
                        cmd.ExecuteNonQuery();                        
                        MessageBox.Show("Ssuccessfully");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Error placing item");
                    return false;
                }
            }
        }

        // 5. Player game play movement
        public bool Player_game_play_movement(int playerID, int targetTileRow, int targetTileCol)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string getLastInsertUserID = "SELECT UserID FROM tb_User ORDER BY UserID DESC LIMIT 1;";
                    using (MySqlCommand cmd = new MySqlCommand(getLastInsertUserID, conn))
                    {
                        object MapID = cmd.ExecuteScalar();
                        // If MapID is not null, then return true, otherwise return false
                        if (MapID != null)
                        {
                            int lastMapID = Convert.ToInt32(MapID);
                            GlobalVariable.UserID = lastMapID;
                        }
                        else
                        {
                            MessageBox.Show("Failed to retrieve UserID.");
                            return false;
                        }
                    }

                    string query = "CALL player_movement(@pPlayerID, @pTileRow, @pTileCol);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pPlayerID", GlobalVariable.UserID);
                        cmd.Parameters.AddWithValue("@pTileRow", targetTileRow);
                        cmd.Parameters.AddWithValue("@pTileCol", targetTileCol);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // If returns at least one record, then return true, otherwise return false
                            if (reader.Read())
                            {
                                // Return result message
                                string message = reader.GetString(0);
                                MessageBox.Show(message);

                                if (message == "Player movement successfully!")
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

        // 6. Game play scoring and 7. Player game play acquiring inventory
        public bool game_play_scoring_and_inventory(int userID, int targetTile)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL game_play_scoring(@UserID, @TargetTile);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@TargetTile", targetTile);

                        // Execute the stored procedure and handle result
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string resultMessage = reader.GetString(0);
                                MessageBox.Show(resultMessage);
                                return true;
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

        // 8. Move an Item (NPC effect)
        public bool move_an_item(int MapID, int itemID, int targetTileID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL move_an_item(@MapID, @ItemID, @TargetTileID);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MapID", GlobalVariable.MapID);
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        cmd.Parameters.AddWithValue("@TargetTileID", targetTileID);

                        // Execute the stored procedure and handle result
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string resultMessage = reader.GetString(0);
                                MessageBox.Show(resultMessage);
                                return true;
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
        public string KillRunningGame(int gameID)
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

                        // Execute the procedure and read the returned message
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetString(0); // Return the result message
                            }
                            else
                            {
                                return "No result returned from the procedure.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return "Error: " + ex.Message;
                }
            }
        }

        // 10. Add new players
        public bool AddPlayer(User user)
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
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        cmd.Parameters.AddWithValue("@LockState", user.LockState);
                        cmd.Parameters.AddWithValue("@IsAdministrator", user.IsAdministrator);

                        int result = cmd.ExecuteNonQuery();
                        Console.WriteLine("You have logged successfully");
                        // Check if the query was successful
                        return result > 0;
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
        public bool CheckUsernameExist(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM tb_user WHERE Username = @username;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdatePlayer(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "CALL update_player(@pUsername, @Email, @pPassword, @pLockState, @pLoginState, @pGameState, @pIsAdministrator);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pUsername", user.Username);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@pPassword", user.Password);
                        cmd.Parameters.AddWithValue("@pLockState", user.LockState);
                        cmd.Parameters.AddWithValue("@pLoginState", user.LoginState);
                        cmd.Parameters.AddWithValue("@pGameState", user.GameState);
                        cmd.Parameters.AddWithValue("@pIsAdministrator", user.IsAdministrator);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return true;
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
        public bool DeletePlayer(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Call procedure rather than query
                    string query = "CALL delete_player(@Email);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to the query
                        // These codes from https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparametercollection.addwithvalue?view=netframework-4.8.1
                        cmd.Parameters.AddWithValue("@Email", user.Email);

                        int result = cmd.ExecuteNonQuery();
                        Console.WriteLine("Delete user successfully");
                        // Check if the query was successful
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // Getting data from tb_tile and used to create game board
        public List<Tile> GetTiles(Map map)
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
                        cmd.Parameters.AddWithValue("@MapID", map.MapID);

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
