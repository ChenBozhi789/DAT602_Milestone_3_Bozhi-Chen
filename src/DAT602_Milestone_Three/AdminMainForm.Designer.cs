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
            this.btnDelPlayer = new System.Windows.Forms.Button();
            this.btnEditPlayer = new System.Windows.Forms.Button();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.btnKillRunningGame = new System.Windows.Forms.Button();
            this.lstAllRegPlayer = new System.Windows.Forms.ListBox();
            this.lstCurrentgame = new System.Windows.Forms.ListBox();
            this.txtDeleteGame = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAllRegPlayer
            // 
            this.lblAllRegPlayer.AutoSize = true;
            this.lblAllRegPlayer.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.lblAllRegPlayer.Location = new System.Drawing.Point(362, 26);
            this.lblAllRegPlayer.Name = "lblAllRegPlayer";
            this.lblAllRegPlayer.Size = new System.Drawing.Size(240, 20);
            this.lblAllRegPlayer.TabIndex = 16;
            this.lblAllRegPlayer.Text = "All Registered Player";
            // 
            // lblCurrentgame
            // 
            this.lblCurrentgame.AutoSize = true;
            this.lblCurrentgame.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurrentgame.Location = new System.Drawing.Point(36, 27);
            this.lblCurrentgame.Name = "lblCurrentgame";
            this.lblCurrentgame.Size = new System.Drawing.Size(141, 20);
            this.lblCurrentgame.TabIndex = 15;
            this.lblCurrentgame.Text = "Current Game";
            // 
            // btnDelPlayer
            // 
            this.btnDelPlayer.AutoSize = true;
            this.btnDelPlayer.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnDelPlayer.Location = new System.Drawing.Point(586, 352);
            this.btnDelPlayer.Name = "btnDelPlayer";
            this.btnDelPlayer.Size = new System.Drawing.Size(93, 43);
            this.btnDelPlayer.TabIndex = 14;
            this.btnDelPlayer.Text = "Delete";
            this.btnDelPlayer.UseVisualStyleBackColor = true;
            // 
            // btnEditPlayer
            // 
            this.btnEditPlayer.AutoSize = true;
            this.btnEditPlayer.Font = new System.Drawing.Font("Calibri", 16F);
            this.btnEditPlayer.Location = new System.Drawing.Point(476, 352);
            this.btnEditPlayer.Name = "btnEditPlayer";
            this.btnEditPlayer.Size = new System.Drawing.Size(93, 43);
            this.btnEditPlayer.TabIndex = 13;
            this.btnEditPlayer.Text = "Edit";
            this.btnEditPlayer.UseVisualStyleBackColor = true;
            this.btnEditPlayer.Click += new System.EventHandler(this.btnEditPlayer_Click);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.AutoSize = true;
            this.btnAddPlayer.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnAddPlayer.Location = new System.Drawing.Point(366, 352);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(93, 43);
            this.btnAddPlayer.TabIndex = 12;
            this.btnAddPlayer.Text = "Add";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // btnKillRunningGame
            // 
            this.btnKillRunningGame.AutoSize = true;
            this.btnKillRunningGame.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnKillRunningGame.Location = new System.Drawing.Point(106, 352);
            this.btnKillRunningGame.Name = "btnKillRunningGame";
            this.btnKillRunningGame.Size = new System.Drawing.Size(203, 43);
            this.btnKillRunningGame.TabIndex = 11;
            this.btnKillRunningGame.Text = "Kill Running Game";
            this.btnKillRunningGame.UseVisualStyleBackColor = true;
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
            this.lstAllRegPlayer.Location = new System.Drawing.Point(366, 49);
            this.lstAllRegPlayer.Name = "lstAllRegPlayer";
            this.lstAllRegPlayer.Size = new System.Drawing.Size(313, 268);
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
            this.lstCurrentgame.Size = new System.Drawing.Size(305, 268);
            this.lstCurrentgame.TabIndex = 9;
            // 
            // txtDeleteGame
            // 
            this.txtDeleteGame.Location = new System.Drawing.Point(40, 352);
            this.txtDeleteGame.Multiline = true;
            this.txtDeleteGame.Name = "txtDeleteGame";
            this.txtDeleteGame.Size = new System.Drawing.Size(51, 43);
            this.txtDeleteGame.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "Enter the game you want to kill";
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 424);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDeleteGame);
            this.Controls.Add(this.lblAllRegPlayer);
            this.Controls.Add(this.lblCurrentgame);
            this.Controls.Add(this.btnDelPlayer);
            this.Controls.Add(this.btnEditPlayer);
            this.Controls.Add(this.btnAddPlayer);
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
        private System.Windows.Forms.Button btnDelPlayer;
        private System.Windows.Forms.Button btnEditPlayer;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Button btnKillRunningGame;
        private System.Windows.Forms.ListBox lstAllRegPlayer;
        private System.Windows.Forms.ListBox lstCurrentgame;
        private System.Windows.Forms.TextBox txtDeleteGame;
        private System.Windows.Forms.Label label1;
    }
}