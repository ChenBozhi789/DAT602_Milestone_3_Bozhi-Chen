using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Map map = new Map
            {
                MapID = MapID
            };
            
            List<Tile> tiles = userDAO.GetTiles(map);

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

                // Add event to the button
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

            bool movementResult = userDAO.Player_game_play_movement(GlobalVariable.UserID, tile.TileRow, tile.TileCol);

            if (movementResult)
            {
                if (clickedButton.BackColor == Color.White)
                {
                    // Item is diamond
                    if (tile.ItemTypeID == 1)
                    {
                        clickedButton.BackColor = Color.Red;
                    }
                    // Item is bomb
                    else if (tile.ItemTypeID == 2)
                    {
                        clickedButton.BackColor = Color.Black;
                    }
                    // If the tile is empty, the tile will be changed to gray
                    else
                    {
                        clickedButton.BackColor = Color.Gray;
                    }
                }
                bool scoringResult = userDAO.game_play_scoring_and_inventory(GlobalVariable.UserID, tile.TileID);
            }
        }

        private void GamePlayForm_Load(object sender, EventArgs e)
        {
            CreateBoard(GlobalVariable.MapID);
        }

        private void btnBackToPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            //this.Close();
            MainGameLobby mainGameLobby = new MainGameLobby();
            mainGameLobby.ShowDialog();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            GlobalVariable.UserID = 1;
            int TileID = Convert.ToInt16(txtStartingTile.Text);
            int targetTileID = Convert.ToInt16(txtTargetTile.Text);
            UserDAO userDAO = new UserDAO();
            bool moveResult = userDAO.move_an_item(GlobalVariable.MapID, TileID, targetTileID);

            if (moveResult)
            {
                MessageBox.Show("Move successfully");
            }
            else
            {
                MessageBox.Show("Move failed");
            }
        }
    }
}