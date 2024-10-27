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
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            AdminManagerForm adminManagerForm = new AdminManagerForm();
            adminManagerForm.ShowDialog();
        }

        private void btnEditPlayer_Click(object sender, EventArgs e)
        {
            AdminManagerForm adminManagerForm = new AdminManagerForm();
            adminManagerForm.ShowDialog();
        }

        private void btnKillRunningGame_Click(object sender, EventArgs e)
        {
            int currentGameID = Convert.ToInt32(txtDeleteGame.Text);
            UserDAO userDAO = new UserDAO();            
            string deleteMessage = userDAO.KillRunningGame(currentGameID);
            MessageBox.Show(deleteMessage);
        }
    }
}
