﻿using System;
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

        private void btnNewgame1_Click(object sender, EventArgs e)
        {
            int maxRow = Convert.ToInt32(txtMaxRow.Text);
            int maxCol = Convert.ToInt32(txtMaxCol.Text);

            Map map = new Map
            {
                MapID = 0,
                MaxRow = maxRow,
                MaxColumn = maxCol
            };
            
            UserDAO userDAO = new UserDAO();

            int currentMapID = userDAO.Laying_out_tiles(map);
            if (currentMapID > 0)
            {
                map.MapID = currentMapID;
                userDAO.Placing_an_item_on_a_tile(map);                
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