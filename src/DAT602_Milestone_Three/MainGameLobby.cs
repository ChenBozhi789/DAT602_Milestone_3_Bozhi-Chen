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
    public partial class MainGameLobby : Form
    {
        public MainGameLobby()
        {
            InitializeComponent();
        }

        private void btnNewgame_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            
            int maxRow = Convert.ToInt32(txtMaxRow.Text);
            int maxCol = Convert.ToInt32(txtMaxCol.Text);
            // Get the last insert MapID (current MapID)
            int currentMapID = userDAO.GetCurrentMapID();

            Map map = new Map
            {
                MapID = currentMapID,
                MaxRow = maxRow,
                MaxColumn = maxCol
            };
            
            bool createGameMapID = userDAO.Laying_out_tiles(map);

            // IF the Map is created successfully, then place the item on the tile
            if (createGameMapID)
            {
                MessageBox.Show("Create game map successfully!");
            } 
            else
            {
                MessageBox.Show("Failed to create the game map!");
            }
            
            this.Hide();
            GamePlayForm gamePlayForm = new GamePlayForm();
            gamePlayForm.ShowDialog();
        }

        private void btnAdminconsole_Click(object sender, EventArgs e)
        {
            AdminMainForm adminMainForm = new AdminMainForm();
            adminMainForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
