namespace DAT602_MIlestone_Three
{
    partial class MainGameLobby
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
            this.btnJoinGame = new System.Windows.Forms.Button();
            this.btnAdminConsole = new System.Windows.Forms.Button();
            this.lblCurrentGame = new System.Windows.Forms.Label();
            this.lblOnlinePlayer = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnNewgame1 = new System.Windows.Forms.Button();
            this.lstOnlinePlayer = new System.Windows.Forms.ListBox();
            this.lstCurrentGame = new System.Windows.Forms.ListBox();
            this.txtMaxRow = new System.Windows.Forms.TextBox();
            this.txtMaxCol = new System.Windows.Forms.TextBox();
            this.lblMaxRow = new System.Windows.Forms.Label();
            this.lblMaxCol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnJoinGame
            // 
            this.btnJoinGame.AutoSize = true;
            this.btnJoinGame.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnJoinGame.Location = new System.Drawing.Point(410, 146);
            this.btnJoinGame.Name = "btnJoinGame";
            this.btnJoinGame.Size = new System.Drawing.Size(208, 43);
            this.btnJoinGame.TabIndex = 28;
            this.btnJoinGame.Text = "Join Game";
            this.btnJoinGame.UseVisualStyleBackColor = true;
            // 
            // btnAdminConsole
            // 
            this.btnAdminConsole.AutoSize = true;
            this.btnAdminConsole.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnAdminConsole.Location = new System.Drawing.Point(411, 192);
            this.btnAdminConsole.Name = "btnAdminConsole";
            this.btnAdminConsole.Size = new System.Drawing.Size(208, 43);
            this.btnAdminConsole.TabIndex = 27;
            this.btnAdminConsole.Text = "Admin Console";
            this.btnAdminConsole.UseVisualStyleBackColor = true;
            this.btnAdminConsole.Click += new System.EventHandler(this.btnAdminconsole_Click);
            // 
            // lblCurrentGame
            // 
            this.lblCurrentGame.AutoSize = true;
            this.lblCurrentGame.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblCurrentGame.Location = new System.Drawing.Point(25, 25);
            this.lblCurrentGame.Name = "lblCurrentGame";
            this.lblCurrentGame.Size = new System.Drawing.Size(154, 29);
            this.lblCurrentGame.TabIndex = 26;
            this.lblCurrentGame.Text = "Current Game";
            // 
            // lblOnlinePlayer
            // 
            this.lblOnlinePlayer.AutoSize = true;
            this.lblOnlinePlayer.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblOnlinePlayer.Location = new System.Drawing.Point(217, 25);
            this.lblOnlinePlayer.Name = "lblOnlinePlayer";
            this.lblOnlinePlayer.Size = new System.Drawing.Size(147, 29);
            this.lblOnlinePlayer.TabIndex = 25;
            this.lblOnlinePlayer.Text = "Online Player";
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSize = true;
            this.btnLogout.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnLogout.Location = new System.Drawing.Point(410, 238);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(208, 43);
            this.btnLogout.TabIndex = 23;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnNewgame1
            // 
            this.btnNewgame1.AutoSize = true;
            this.btnNewgame1.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnNewgame1.Location = new System.Drawing.Point(411, 100);
            this.btnNewgame1.Name = "btnNewgame1";
            this.btnNewgame1.Size = new System.Drawing.Size(208, 43);
            this.btnNewgame1.TabIndex = 22;
            this.btnNewgame1.Text = "Create Game!";
            this.btnNewgame1.UseVisualStyleBackColor = true;
            this.btnNewgame1.Click += new System.EventHandler(this.btnNewgame1_Click);
            // 
            // lstOnlinePlayer
            // 
            this.lstOnlinePlayer.Font = new System.Drawing.Font("Calibri", 12F);
            this.lstOnlinePlayer.FormattingEnabled = true;
            this.lstOnlinePlayer.ItemHeight = 24;
            this.lstOnlinePlayer.Items.AddRange(new object[] {
            "Bozhi\t2000",
            "Josef\t1200\t\t",
            "Super\t7000"});
            this.lstOnlinePlayer.Location = new System.Drawing.Point(221, 63);
            this.lstOnlinePlayer.Name = "lstOnlinePlayer";
            this.lstOnlinePlayer.Size = new System.Drawing.Size(173, 220);
            this.lstOnlinePlayer.TabIndex = 21;
            // 
            // lstCurrentGame
            // 
            this.lstCurrentGame.Font = new System.Drawing.Font("Calibri", 12F);
            this.lstCurrentGame.FormattingEnabled = true;
            this.lstCurrentGame.ItemHeight = 24;
            this.lstCurrentGame.Items.AddRange(new object[] {
            "Game 1v1(1)",
            "Game 1v1(2)",
            "Game 2v2(1)",
            "Game 3v3(1)"});
            this.lstCurrentGame.Location = new System.Drawing.Point(29, 63);
            this.lstCurrentGame.Name = "lstCurrentGame";
            this.lstCurrentGame.Size = new System.Drawing.Size(173, 220);
            this.lstCurrentGame.TabIndex = 20;
            // 
            // txtMaxRow
            // 
            this.txtMaxRow.Location = new System.Drawing.Point(411, 63);
            this.txtMaxRow.Multiline = true;
            this.txtMaxRow.Name = "txtMaxRow";
            this.txtMaxRow.Size = new System.Drawing.Size(94, 31);
            this.txtMaxRow.TabIndex = 30;
            // 
            // txtMaxCol
            // 
            this.txtMaxCol.Location = new System.Drawing.Point(523, 62);
            this.txtMaxCol.Multiline = true;
            this.txtMaxCol.Name = "txtMaxCol";
            this.txtMaxCol.Size = new System.Drawing.Size(94, 31);
            this.txtMaxCol.TabIndex = 31;
            // 
            // lblMaxRow
            // 
            this.lblMaxRow.AutoSize = true;
            this.lblMaxRow.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblMaxRow.Location = new System.Drawing.Point(406, 30);
            this.lblMaxRow.Name = "lblMaxRow";
            this.lblMaxRow.Size = new System.Drawing.Size(102, 29);
            this.lblMaxRow.TabIndex = 32;
            this.lblMaxRow.Text = "MaxRow";
            // 
            // lblMaxCol
            // 
            this.lblMaxCol.AutoSize = true;
            this.lblMaxCol.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblMaxCol.Location = new System.Drawing.Point(518, 30);
            this.lblMaxCol.Name = "lblMaxCol";
            this.lblMaxCol.Size = new System.Drawing.Size(89, 29);
            this.lblMaxCol.TabIndex = 33;
            this.lblMaxCol.Text = "MaxCol";
            // 
            // MainGameLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 300);
            this.Controls.Add(this.lblMaxCol);
            this.Controls.Add(this.lblMaxRow);
            this.Controls.Add(this.txtMaxCol);
            this.Controls.Add(this.txtMaxRow);
            this.Controls.Add(this.btnJoinGame);
            this.Controls.Add(this.btnAdminConsole);
            this.Controls.Add(this.lblCurrentGame);
            this.Controls.Add(this.lblOnlinePlayer);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnNewgame1);
            this.Controls.Add(this.lstOnlinePlayer);
            this.Controls.Add(this.lstCurrentGame);
            this.Name = "MainGameLobby";
            this.Text = "MainGameLobby";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnJoinGame;
        private System.Windows.Forms.Button btnAdminConsole;
        private System.Windows.Forms.Label lblCurrentGame;
        private System.Windows.Forms.Label lblOnlinePlayer;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnNewgame1;
        private System.Windows.Forms.ListBox lstOnlinePlayer;
        private System.Windows.Forms.ListBox lstCurrentGame;
        private System.Windows.Forms.TextBox txtMaxRow;
        private System.Windows.Forms.TextBox txtMaxCol;
        private System.Windows.Forms.Label lblMaxRow;
        private System.Windows.Forms.Label lblMaxCol;
    }
}