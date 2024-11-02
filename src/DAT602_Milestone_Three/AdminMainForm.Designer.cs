namespace DAT602_MIlestone_Three
{
    partial class AdminMainForm
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
            this.lblAllRegPlayer = new System.Windows.Forms.Label();
            this.lblCurrentgame = new System.Windows.Forms.Label();
            this.btnEditPlayer = new System.Windows.Forms.Button();
            this.btnManagePlayer = new System.Windows.Forms.Button();
            this.btnKillRunningGame = new System.Windows.Forms.Button();
            this.lstAllRegPlayer = new System.Windows.Forms.ListBox();
            this.lstCurrentgame = new System.Windows.Forms.ListBox();
            this.txtDeleteGame = new System.Windows.Forms.TextBox();
            this.txtTargetGame = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAllRegPlayer
            // 
            this.lblAllRegPlayer.AutoSize = true;
            this.lblAllRegPlayer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblAllRegPlayer.Location = new System.Drawing.Point(310, 22);
            this.lblAllRegPlayer.Name = "lblAllRegPlayer";
            this.lblAllRegPlayer.Size = new System.Drawing.Size(182, 24);
            this.lblAllRegPlayer.TabIndex = 16;
            this.lblAllRegPlayer.Text = "All Registered Player";
            // 
            // lblCurrentgame
            // 
            this.lblCurrentgame.AutoSize = true;
            this.lblCurrentgame.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurrentgame.Location = new System.Drawing.Point(36, 22);
            this.lblCurrentgame.Name = "lblCurrentgame";
            this.lblCurrentgame.Size = new System.Drawing.Size(128, 24);
            this.lblCurrentgame.TabIndex = 15;
            this.lblCurrentgame.Text = "Current Game";
            // 
            // btnEditPlayer
            // 
            this.btnEditPlayer.AutoSize = true;
            this.btnEditPlayer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEditPlayer.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnEditPlayer.Location = new System.Drawing.Point(314, 402);
            this.btnEditPlayer.Name = "btnEditPlayer";
            this.btnEditPlayer.Size = new System.Drawing.Size(247, 39);
            this.btnEditPlayer.TabIndex = 13;
            this.btnEditPlayer.Text = "Edit Player";
            this.btnEditPlayer.UseVisualStyleBackColor = false;
            this.btnEditPlayer.Click += new System.EventHandler(this.btnEditPlayer_Click);
            // 
            // btnManagePlayer
            // 
            this.btnManagePlayer.AutoSize = true;
            this.btnManagePlayer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnManagePlayer.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnManagePlayer.Location = new System.Drawing.Point(40, 402);
            this.btnManagePlayer.Name = "btnManagePlayer";
            this.btnManagePlayer.Size = new System.Drawing.Size(247, 39);
            this.btnManagePlayer.TabIndex = 12;
            this.btnManagePlayer.Text = "Manage Player";
            this.btnManagePlayer.UseVisualStyleBackColor = false;
            this.btnManagePlayer.Click += new System.EventHandler(this.btnManagePlayer_Click);
            // 
            // btnKillRunningGame
            // 
            this.btnKillRunningGame.AutoSize = true;
            this.btnKillRunningGame.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnKillRunningGame.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnKillRunningGame.Location = new System.Drawing.Point(317, 357);
            this.btnKillRunningGame.Name = "btnKillRunningGame";
            this.btnKillRunningGame.Size = new System.Drawing.Size(247, 39);
            this.btnKillRunningGame.TabIndex = 11;
            this.btnKillRunningGame.Text = "Kill Running Game";
            this.btnKillRunningGame.UseVisualStyleBackColor = false;
            this.btnKillRunningGame.Click += new System.EventHandler(this.btnKillRunningGame_Click);
            // 
            // lstAllRegPlayer
            // 
            this.lstAllRegPlayer.Font = new System.Drawing.Font("Calibri", 12F);
            this.lstAllRegPlayer.FormattingEnabled = true;
            this.lstAllRegPlayer.ItemHeight = 24;
            this.lstAllRegPlayer.Items.AddRange(new object[] {
            "Bozhi",
            "Josef",
            "Super"});
            this.lstAllRegPlayer.Location = new System.Drawing.Point(314, 49);
            this.lstAllRegPlayer.Name = "lstAllRegPlayer";
            this.lstAllRegPlayer.Size = new System.Drawing.Size(248, 268);
            this.lstAllRegPlayer.TabIndex = 10;
            // 
            // lstCurrentgame
            // 
            this.lstCurrentgame.Font = new System.Drawing.Font("Calibri", 12F);
            this.lstCurrentgame.FormattingEnabled = true;
            this.lstCurrentgame.ItemHeight = 24;
            this.lstCurrentgame.Items.AddRange(new object[] {
            "Game 1v1(1)",
            "Game 1v1(2)",
            "Game 2v2(1)",
            "Game 3v3(1)"});
            this.lstCurrentgame.Location = new System.Drawing.Point(39, 49);
            this.lstCurrentgame.Name = "lstCurrentgame";
            this.lstCurrentgame.Size = new System.Drawing.Size(248, 268);
            this.lstCurrentgame.TabIndex = 9;
            // 
            // txtDeleteGame
            // 
            this.txtDeleteGame.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtDeleteGame.Location = new System.Drawing.Point(39, 357);
            this.txtDeleteGame.Multiline = true;
            this.txtDeleteGame.Name = "txtDeleteGame";
            this.txtDeleteGame.Size = new System.Drawing.Size(247, 34);
            this.txtDeleteGame.TabIndex = 35;
            this.txtDeleteGame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTargetGame
            // 
            this.txtTargetGame.AutoSize = true;
            this.txtTargetGame.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.txtTargetGame.Location = new System.Drawing.Point(36, 325);
            this.txtTargetGame.Name = "txtTargetGame";
            this.txtTargetGame.Size = new System.Drawing.Size(324, 29);
            this.txtTargetGame.TabIndex = 36;
            this.txtTargetGame.Text = "Enter the game you want to kill";
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 468);
            this.Controls.Add(this.txtTargetGame);
            this.Controls.Add(this.txtDeleteGame);
            this.Controls.Add(this.lblAllRegPlayer);
            this.Controls.Add(this.lblCurrentgame);
            this.Controls.Add(this.btnEditPlayer);
            this.Controls.Add(this.btnManagePlayer);
            this.Controls.Add(this.btnKillRunningGame);
            this.Controls.Add(this.lstAllRegPlayer);
            this.Controls.Add(this.lstCurrentgame);
            this.Name = "AdminMainForm";
            this.Text = "AdminMainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAllRegPlayer;
        private System.Windows.Forms.Label lblCurrentgame;
        private System.Windows.Forms.Button btnEditPlayer;
        private System.Windows.Forms.Button btnManagePlayer;
        private System.Windows.Forms.Button btnKillRunningGame;
        private System.Windows.Forms.ListBox lstAllRegPlayer;
        private System.Windows.Forms.ListBox lstCurrentgame;
        private System.Windows.Forms.TextBox txtDeleteGame;
        private System.Windows.Forms.Label txtTargetGame;
    }
}