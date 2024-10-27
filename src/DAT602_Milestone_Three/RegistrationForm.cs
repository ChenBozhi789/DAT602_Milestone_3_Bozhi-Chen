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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Veirify all required fields are filled
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPwd.Text) || string.IsNullOrWhiteSpace(txtRepwd.Text))
            {
                MessageBox.Show("Please fill in all required fields");
                return;
            }

            // Verify fields length
            // Username
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

            // Password
            if (txtPwd.Text.Length < 6 || txtPwd.Text.Length > 12)
            {
                MessageBox.Show("Password length must between 6 to 12 characters");
                return;
            }

            // Get user input from input fields
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPwd.Text;

            User user = new User
            {
                Username = username,
                Email = email,
                Password = password
            };

            // Create a instance of the UserDAO class
            UserDAO userDAO = new UserDAO();

            if (txtPwd.Text.Trim() != txtRepwd.Text)
            {
                MessageBox.Show("The Passwords you entered twice do not match");
            } else
            {
                // Call Register function from UserDAO class
                bool isRegistered = userDAO.Register(user);
                // Return prompt to the user
                if (isRegistered)
                {
                    MessageBox.Show("Player registered successfully");
                    this.Hide();
                    LoginForm loginForm = new LoginForm();
                    loginForm.ShowDialog();                    
                }
                else
                {
                    MessageBox.Show("User registration failed");
                }
            }
        }
    }
}
