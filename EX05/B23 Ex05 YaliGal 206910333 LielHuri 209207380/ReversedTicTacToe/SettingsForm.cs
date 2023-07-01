using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex02;

namespace ReversedTicTacToe
{
    public partial class SettingsForm : Form
    {
        internal GameSettings GameSettings { get; private set; }

        internal ePlayerType Player2Type { get; private set; } = ePlayerType.CPU;

        internal bool StartGame { get; private set; } = false;
        
        private GameSettings m_Settings;
        private ePlayerType m_Player2Type;


        public GameSettings Settings { get; }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string[] playersNames = { this.player1Name.Text, this.player2Name.Text };
            ePlayerType[] playersType = { ePlayerType.User, Player2Type };
            int boardSize = (int)this.numberOfRows.Value;
            GameSettings = new GameSettings(playersNames, playersType, boardSize);
            StartGame = true;
            this.Close();
        }

        private void isComputer_Click(object sender, EventArgs e)
        {
            bool isCheckBoxChecked = (sender as CheckBox).Checked;

            this.player2Name.Enabled = isCheckBoxChecked;
            this.player2Name.TabStop = isCheckBoxChecked;
            if (isCheckBoxChecked)
            {
                this.player2Name.Text = null;
                this.player2Name.BackColor = Color.White;
                Player2Type = ePlayerType.User;
            }
            else
            {
                this.player2Name.Text = "[Computer]";
                this.player2Name.BackColor = Color.Silver;
                Player2Type = ePlayerType.CPU;
            }
        }

        private void numberOfRows_ValueChanged(object sender, EventArgs e)
        {
            this.numberOfColumns.Value = (sender as NumericUpDown).Value;
        }

        private void numberOfColumns_ValueChanged(object sender, EventArgs e)
        {
            this.numberOfRows.Value = (sender as NumericUpDown).Value;
        }
    }
}
