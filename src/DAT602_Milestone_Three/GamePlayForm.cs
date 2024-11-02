using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Datatypes.Scalar.Types;

namespace DAT602_MIlestone_Three
{
    public partial class GamePlayForm : Form
    {
        public GamePlayForm()
        {
            InitializeComponent();            
        }

        private void CreateBoard(int MapID)
        {
            UserDAO userDAO = new UserDAO();
            
            List<Tile> tiles = userDAO.GetTiles();

            foreach (Tile tile in tiles)
            {
                int btny = 30;
                Button btn = new Button();
                // Initial colour of the button
                btn.Size = new Size(30, 30);
                btn.Location = new Point(tile.TileRow * 30, (tile.TileCol * 30) + btny);
                btn.Name = $"btn_{tile.TileRow}_{tile.TileCol}";

                if (tile.TileRow == 0 && tile.TileCol == 0)
                {
                    // Default color of the first tile is gray
                    btn.BackColor = Color.Gray;
                }
                else
                {
                    // Default color of the last tile is white
                    btn.BackColor = Color.White;
                }

                // Add (bind) event to the button
                btn.Click += (sender, e) => TestedButton_Click(sender, e, tile);

                //Add button to the game board
                gbBoard.Controls.Add(btn);                
            }
        }

        private void TestedButton_Click(object sender, EventArgs e, Tile tile)
        {
            UserDAO userDAO = new UserDAO();
            // When player click tile, the event will be triggered
            Button clickedButton = sender as Button;

            int currentMapID = userDAO.GetCurrentMapID();
            int currentPlayerID = userDAO.GetCurrentPlayerID();
            int currentTileID = userDAO.GetCurrentTileID(tile.TileRow, tile.TileCol);

            bool movementResult = userDAO.Player_game_play_movement(currentMapID, currentPlayerID, currentTileID);

            // If the movement is successful, the scoring will be updated
            if (movementResult)
            {
                int currentItemType = userDAO.Add_item_to_inventory(currentMapID, currentPlayerID, currentTileID);
                
                if (currentItemType == 1)
                {
                    MessageBox.Show("Score + 10");
                    clickedButton.BackColor = Color.Red;
                }
                else if (currentItemType == 2)
                {
                    MessageBox.Show("Score - 5");
                    clickedButton.BackColor = Color.Black;
                }
                else
                {
                    clickedButton.BackColor = Color.Gray;
                    return;
                }
                
            } else
            {
                return;
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            int startingTileID = Convert.ToInt16(txtStartingTile.Text);
            int targetTileID = Convert.ToInt16(txtTargetTile.Text);

            UserDAO userDAO = new UserDAO();
            bool moveResult = userDAO.move_an_item(GlobalVariable.MapID, startingTileID, targetTileID);

            if (moveResult)
            {
                MessageBox.Show("Move successfully");
            }
            else
            {
                MessageBox.Show("Move failed");
            }
        }

        private void btnBackToPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            //this.Close();
            MainGameLobby mainGameLobby = new MainGameLobby();
            mainGameLobby.ShowDialog();
        }

        private void GamePlayForm_Load(object sender, EventArgs e)
        {
            CreateBoard(GlobalVariable.MapID);
        }
    }
}