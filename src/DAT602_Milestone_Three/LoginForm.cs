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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPwd.Text;

            // Veirify all required fields are filled
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPwd.Text))
            {
                MessageBox.Show("Please fill in all required fields");
                return;
            }

            UserDAO userDAO = new UserDAO();
            // call Login function of userDAO
            int loginResult = userDAO.Login(email, password);

            // Respond based on login results
            if (loginResult == 1)
            {
                MessageBox.Show("Login Successfully！");
                this.Hide();
                // Open the main game lobby
                MainGameLobby mainGameLobby = new MainGameLobby();
                mainGameLobby.ShowDialog();
            }
            else if (loginResult == 0)
            {
                MessageBox.Show("\"Invalid credentials! Attempt + 1\"");                
            }
            else if (loginResult == -1)
            {
                MessageBox.Show("Account is locked, please contact the administrator");
            }
            else if (loginResult == -2)
            {   
                MessageBox.Show("This account is not exists, Check your enter please");
            }
        }
    }
}
