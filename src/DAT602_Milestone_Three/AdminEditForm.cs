using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DAT602_MIlestone_Three
{
    public partial class AdminEditForm : Form
    {
        public AdminEditForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Veirify all required fields are filled
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPwd.Text))
            {
                MessageBox.Show("Please fill in all required fields");
                return;
            }

            // Verify fields length
            if (txtUsername.Text.Length < 6 || txtUsername.Text.Length > 12)
            {
                MessageBox.Show("Username length must between 6 to 12 characters");
                return;
            }

            // Verify Email format
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address");
                return;
            }

            // Varify Password
            if (txtPwd.Text.Length < 6 || txtPwd.Text.Length > 12)
            {
                MessageBox.Show("Password length must between 6 to 12 characters");
                return;
            }

            // Get user input from input fields
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPwd.Text;
            int lockstate = chkIsLocked.Checked ? 1 : 0;
            int isadministrator = chkIsAdmin.Checked ? 1 : 0;

            // Create a instance of the UserDAO class
            UserDAO userDAO = new UserDAO();

            Player player = new Player
            {
                Username = username,
                Email = email,
                Password = password,
                LockState = lockstate,
                IsAdministrator = isadministrator
            };

            // Add player if username does not exist
            bool isEdited = userDAO.UpdatePlayer(player);
            if (isEdited)
            {
                MessageBox.Show("Player edited successfully");
            }
            else
            {
                MessageBox.Show("Player edited failed." + Environment.NewLine + "Reason: This player doesn't exist!");
            }
        }
    }
}
