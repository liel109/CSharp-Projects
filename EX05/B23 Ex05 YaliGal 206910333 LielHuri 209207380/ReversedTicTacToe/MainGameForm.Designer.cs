namespace ReversedTicTacToe
{
    partial class MainGameForm
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
            this.playerOneLabel = new System.Windows.Forms.Label();
            this.playerOneScore = new System.Windows.Forms.Label();
            this.playerTwoScore = new System.Windows.Forms.Label();
            this.playerTwoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playerOneLabel
            // 
            this.playerOneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerOneLabel.AutoSize = true;
            this.playerOneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerOneLabel.Location = new System.Drawing.Point(137, 691);
            this.playerOneLabel.MaximumSize = new System.Drawing.Size(110, 30);
            this.playerOneLabel.Name = "playerOneLabel";
            this.playerOneLabel.Size = new System.Drawing.Size(78, 20);
            this.playerOneLabel.TabIndex = 0;
            this.playerOneLabel.Text = "Player 1:";
            // 
            // playerOneScore
            // 
            this.playerOneScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerOneScore.AutoSize = true;
            this.playerOneScore.Location = new System.Drawing.Point(212, 691);
            this.playerOneScore.Name = "playerOneScore";
            this.playerOneScore.Size = new System.Drawing.Size(18, 20);
            this.playerOneScore.TabIndex = 1;
            this.playerOneScore.Text = "0";
            // 
            // playerTwoScore
            // 
            this.playerTwoScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerTwoScore.AutoSize = true;
            this.playerTwoScore.Location = new System.Drawing.Point(406, 691);
            this.playerTwoScore.Name = "playerTwoScore";
            this.playerTwoScore.Size = new System.Drawing.Size(18, 20);
            this.playerTwoScore.TabIndex = 3;
            this.playerTwoScore.Text = "0";
            // 
            // playerTwoLabel
            // 
            this.playerTwoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerTwoLabel.AutoSize = true;
            this.playerTwoLabel.Location = new System.Drawing.Point(331, 691);
            this.playerTwoLabel.MaximumSize = new System.Drawing.Size(110, 30);
            this.playerTwoLabel.Name = "playerTwoLabel";
            this.playerTwoLabel.Size = new System.Drawing.Size(69, 20);
            this.playerTwoLabel.TabIndex = 2;
            this.playerTwoLabel.Text = "Player 2:";
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 738);
            this.Controls.Add(this.playerTwoScore);
            this.Controls.Add(this.playerTwoLabel);
            this.Controls.Add(this.playerOneScore);
            this.Controls.Add(this.playerOneLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainGameForm";
            this.ShowIcon = false;
            this.Text = "GameBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playerOneLabel;
        private System.Windows.Forms.Label playerOneScore;
        private System.Windows.Forms.Label playerTwoScore;
        private System.Windows.Forms.Label playerTwoLabel;
    }
}