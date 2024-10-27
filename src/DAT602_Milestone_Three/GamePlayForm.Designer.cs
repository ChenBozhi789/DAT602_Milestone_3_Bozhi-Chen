namespace DAT602_MIlestone_Three
{
    partial class GamePlayForm
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
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.gbPlayera = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.gbBoard = new System.Windows.Forms.GroupBox();
            this.btnBackToPage = new System.Windows.Forms.Button();
            this.txtStartingTile = new System.Windows.Forms.TextBox();
            this.txtTargetTile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStartingTile = new System.Windows.Forms.Label();
            this.btnMove = new System.Windows.Forms.Button();
            this.gbPlayera.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Calibri", 15F);
            this.lblTime.Location = new System.Drawing.Point(630, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(136, 31);
            this.lblTime.TabIndex = 18;
            this.lblTime.Text = "Time: 00:00";
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("Calibri", 15F);
            this.lblTurn.Location = new System.Drawing.Point(540, 9);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(72, 31);
            this.lblTurn.TabIndex = 17;
            this.lblTurn.Text = "Turn: ";
            // 
            // gbPlayera
            // 
            this.gbPlayera.Controls.Add(this.label2);
            this.gbPlayera.Controls.Add(this.textBox2);
            this.gbPlayera.Controls.Add(this.label7);
            this.gbPlayera.Controls.Add(this.textBox5);
            this.gbPlayera.Controls.Add(this.textBox6);
            this.gbPlayera.Controls.Add(this.label3);
            this.gbPlayera.Controls.Add(this.label4);
            this.gbPlayera.Controls.Add(this.label5);
            this.gbPlayera.Controls.Add(this.textBox3);
            this.gbPlayera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbPlayera.Font = new System.Drawing.Font("Calibri", 15F);
            this.gbPlayera.Location = new System.Drawing.Point(534, 46);
            this.gbPlayera.Name = "gbPlayera";
            this.gbPlayera.Size = new System.Drawing.Size(319, 235);
            this.gbPlayera.TabIndex = 15;
            this.gbPlayera.TabStop = false;
            this.gbPlayera.Text = "PlayerA State";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15F);
            this.label2.Location = new System.Drawing.Point(26, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Score";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(105, 190);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(107, 30);
            this.textBox2.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15F);
            this.label7.Location = new System.Drawing.Point(176, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 31);
            this.label7.TabIndex = 13;
            this.label7.Text = "Bomb";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(102, 139);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(50, 30);
            this.textBox5.TabIndex = 14;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(256, 140);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(50, 30);
            this.textBox6.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15F);
            this.label3.Location = new System.Drawing.Point(30, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 31);
            this.label3.TabIndex = 12;
            this.label3.Text = "Inventory";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15F);
            this.label4.Location = new System.Drawing.Point(26, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 31);
            this.label4.TabIndex = 12;
            this.label4.Text = "Jewel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15F);
            this.label5.Location = new System.Drawing.Point(26, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 31);
            this.label5.TabIndex = 12;
            this.label5.Text = "Name";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(109, 43);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(107, 30);
            this.textBox3.TabIndex = 13;
            // 
            // gbBoard
            // 
            this.gbBoard.AutoSize = true;
            this.gbBoard.Font = new System.Drawing.Font("Calibri", 15F);
            this.gbBoard.Location = new System.Drawing.Point(31, 27);
            this.gbBoard.Name = "gbBoard";
            this.gbBoard.Size = new System.Drawing.Size(479, 438);
            this.gbBoard.TabIndex = 14;
            this.gbBoard.TabStop = false;
            this.gbBoard.Text = "Game Map";
            // 
            // btnBackToPage
            // 
            this.btnBackToPage.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.btnBackToPage.Location = new System.Drawing.Point(538, 423);
            this.btnBackToPage.Name = "btnBackToPage";
            this.btnBackToPage.Size = new System.Drawing.Size(212, 42);
            this.btnBackToPage.TabIndex = 19;
            this.btnBackToPage.Text = "Back To Prev Page";
            this.btnBackToPage.UseVisualStyleBackColor = true;
            this.btnBackToPage.Click += new System.EventHandler(this.btnBackToPage_Click);
            // 
            // txtStartingTile
            // 
            this.txtStartingTile.Location = new System.Drawing.Point(656, 340);
            this.txtStartingTile.Name = "txtStartingTile";
            this.txtStartingTile.Size = new System.Drawing.Size(78, 25);
            this.txtStartingTile.TabIndex = 20;
            // 
            // txtTargetTile
            // 
            this.txtTargetTile.Location = new System.Drawing.Point(656, 381);
            this.txtTargetTile.Name = "txtTargetTile";
            this.txtTargetTile.Size = new System.Drawing.Size(80, 25);
            this.txtTargetTile.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14F);
            this.label6.Location = new System.Drawing.Point(541, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 29);
            this.label6.TabIndex = 23;
            this.label6.Text = "Click button to move an item!";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(541, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 24);
            this.label8.TabIndex = 24;
            this.label8.Text = "Target Tile";
            // 
            // lblStartingTile
            // 
            this.lblStartingTile.AutoSize = true;
            this.lblStartingTile.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblStartingTile.Location = new System.Drawing.Point(541, 340);
            this.lblStartingTile.Name = "lblStartingTile";
            this.lblStartingTile.Size = new System.Drawing.Size(110, 24);
            this.lblStartingTile.TabIndex = 25;
            this.lblStartingTile.Text = "Starting Tile";
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnMove.Location = new System.Drawing.Point(742, 355);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(91, 35);
            this.btnMove.TabIndex = 26;
            this.btnMove.Text = "Move!";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // GamePlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 494);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.lblStartingTile);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTargetTile);
            this.Controls.Add(this.txtStartingTile);
            this.Controls.Add(this.btnBackToPage);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.gbPlayera);
            this.Controls.Add(this.gbBoard);
            this.Name = "GamePlayForm";
            this.Text = "GamePlayForm";
            this.Load += new System.EventHandler(this.GamePlayForm_Load);
            this.gbPlayera.ResumeLayout(false);
            this.gbPlayera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.GroupBox gbPlayera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox gbBoard;
        private System.Windows.Forms.Button btnBackToPage;
        private System.Windows.Forms.TextBox txtStartingTile;
        private System.Windows.Forms.TextBox txtTargetTile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStartingTile;
        private System.Windows.Forms.Button btnMove;
    }
}