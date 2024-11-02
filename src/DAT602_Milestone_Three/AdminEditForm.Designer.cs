namespace DAT602_MIlestone_Three
{
    partial class AdminEditForm
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.chkIsAdmin = new System.Windows.Forms.CheckBox();
            this.chkIsLocked = new System.Windows.Forms.CheckBox();
            this.lblPlayerInfo = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnConfirm.Location = new System.Drawing.Point(49, 329);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(206, 42);
            this.btnConfirm.TabIndex = 36;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // chkIsAdmin
            // 
            this.chkIsAdmin.AutoSize = true;
            this.chkIsAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkIsAdmin.Location = new System.Drawing.Point(165, 285);
            this.chkIsAdmin.Name = "chkIsAdmin";
            this.chkIsAdmin.Size = new System.Drawing.Size(90, 29);
            this.chkIsAdmin.TabIndex = 34;
            this.chkIsAdmin.Text = "Admin";
            this.chkIsAdmin.UseVisualStyleBackColor = true;
            // 
            // chkIsLocked
            // 
            this.chkIsLocked.AutoSize = true;
            this.chkIsLocked.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkIsLocked.Location = new System.Drawing.Point(52, 285);
            this.chkIsLocked.Name = "chkIsLocked";
            this.chkIsLocked.Size = new System.Drawing.Size(98, 29);
            this.chkIsLocked.TabIndex = 33;
            this.chkIsLocked.Text = "Locked";
            this.chkIsLocked.UseVisualStyleBackColor = true;
            // 
            // lblPlayerInfo
            // 
            this.lblPlayerInfo.AutoSize = true;
            this.lblPlayerInfo.Font = new System.Drawing.Font("Calibri", 16F);
            this.lblPlayerInfo.Location = new System.Drawing.Point(12, 37);
            this.lblPlayerInfo.Name = "lblPlayerInfo";
            this.lblPlayerInfo.Size = new System.Drawing.Size(264, 33);
            this.lblPlayerInfo.TabIndex = 40;
            this.lblPlayerInfo.Text = "Edit Player Information";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(49, 247);
            this.txtPwd.Multiline = true;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(206, 30);
            this.txtPwd.TabIndex = 32;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(49, 115);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(206, 30);
            this.txtUsername.TabIndex = 30;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(49, 181);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(206, 30);
            this.txtEmail.TabIndex = 31;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblEmail.Location = new System.Drawing.Point(54, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(68, 29);
            this.lblEmail.TabIndex = 39;
            this.lblEmail.Text = "Email";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblPwd.Location = new System.Drawing.Point(45, 217);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(105, 29);
            this.lblPwd.TabIndex = 38;
            this.lblPwd.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblUsername.Location = new System.Drawing.Point(45, 85);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(113, 29);
            this.lblUsername.TabIndex = 37;
            this.lblUsername.Text = "Username";
            // 
            // AdminEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 394);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.chkIsAdmin);
            this.Controls.Add(this.chkIsLocked);
            this.Controls.Add(this.lblPlayerInfo);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblUsername);
            this.Name = "AdminEditForm";
            this.Text = "AdminEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.CheckBox chkIsAdmin;
        private System.Windows.Forms.CheckBox chkIsLocked;
        private System.Windows.Forms.Label lblPlayerInfo;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblUsername;
    }
}