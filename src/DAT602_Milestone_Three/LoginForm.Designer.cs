namespace DAT602_MIlestone_Three
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblGamename = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(98, 171);
            this.txtPwd.Multiline = true;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(220, 30);
            this.txtPwd.TabIndex = 25;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(98, 105);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 30);
            this.txtEmail.TabIndex = 24;
            // 
            // btnContinue
            // 
            this.btnContinue.AutoSize = true;
            this.btnContinue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnContinue.Location = new System.Drawing.Point(146, 220);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(112, 38);
            this.btnContinue.TabIndex = 23;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(92, 71);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(70, 31);
            this.lblEmail.TabIndex = 22;
            this.lblEmail.Text = "Email";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.lblPwd.Location = new System.Drawing.Point(94, 141);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(113, 31);
            this.lblPwd.TabIndex = 21;
            this.lblPwd.Text = "Password";
            // 
            // lblGamename
            // 
            this.lblGamename.AutoSize = true;
            this.lblGamename.Font = new System.Drawing.Font("Calibri", 20F);
            this.lblGamename.Location = new System.Drawing.Point(105, 20);
            this.lblGamename.Name = "lblGamename";
            this.lblGamename.Size = new System.Drawing.Size(185, 41);
            this.lblGamename.TabIndex = 20;
            this.lblGamename.Text = "Player Login";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 286);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblGamename);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblGamename;
    }
}