namespace ReversedTicTacToe
{
    public partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.player1Name = new System.Windows.Forms.TextBox();
            this.isComputer = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.player2Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numberOfRows = new System.Windows.Forms.NumericUpDown();
            this.numberOfColumns = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 1:";
            // 
            // player1Name
            // 
            this.player1Name.Location = new System.Drawing.Point(170, 57);
            this.player1Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(148, 26);
            this.player1Name.TabIndex = 100;
            this.player1Name.Enter += new System.EventHandler(this.playerName_Enter);
            // 
            // isComputer
            // 
            this.isComputer.AutoSize = true;
            this.isComputer.Location = new System.Drawing.Point(48, 112);
            this.isComputer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.isComputer.Name = "isComputer";
            this.isComputer.Size = new System.Drawing.Size(22, 21);
            this.isComputer.TabIndex = 200;
            this.isComputer.UseVisualStyleBackColor = true;
            this.isComputer.Click += new System.EventHandler(this.isComputer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Player 2:";
            // 
            // player2Name
            // 
            this.player2Name.BackColor = System.Drawing.Color.Silver;
            this.player2Name.Enabled = false;
            this.player2Name.Location = new System.Drawing.Point(170, 108);
            this.player2Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(148, 26);
            this.player2Name.TabIndex = 300;
            this.player2Name.TabStop = false;
            this.player2Name.Text = "[Computer]";
            this.player2Name.Enter += new System.EventHandler(this.playerName_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Board Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 217);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Rows:";
            // 
            // numberOfRows
            // 
            this.numberOfRows.Location = new System.Drawing.Point(123, 214);
            this.numberOfRows.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numberOfRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberOfRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberOfRows.Name = "numberOfRows";
            this.numberOfRows.ReadOnly = true;
            this.numberOfRows.Size = new System.Drawing.Size(52, 26);
            this.numberOfRows.TabIndex = 400;
            this.numberOfRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberOfRows.ValueChanged += new System.EventHandler(this.columnsOrRows_ValueChanged);
            // 
            // numberOfColumns
            // 
            this.numberOfColumns.Location = new System.Drawing.Point(267, 214);
            this.numberOfColumns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numberOfColumns.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberOfColumns.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberOfColumns.Name = "numberOfColumns";
            this.numberOfColumns.ReadOnly = true;
            this.numberOfColumns.Size = new System.Drawing.Size(52, 26);
            this.numberOfColumns.TabIndex = 500;
            this.numberOfColumns.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberOfColumns.ValueChanged += new System.EventHandler(this.columnsOrRows_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 217);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cols:";
            // 
            // buttonStart
            // 
            this.buttonStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStart.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStart.Location = new System.Drawing.Point(27, 278);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(292, 35);
            this.buttonStart.TabIndex = 600;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 346);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numberOfColumns);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numberOfRows);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.player2Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.isComputer);
            this.Controls.Add(this.player1Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox player1Name;
        private System.Windows.Forms.CheckBox isComputer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox player2Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numberOfRows;
        private System.Windows.Forms.NumericUpDown numberOfColumns;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonStart;
    }
}
