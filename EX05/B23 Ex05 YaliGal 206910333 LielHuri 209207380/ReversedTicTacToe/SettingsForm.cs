using System;
using System.Drawing;
using System.Windows.Forms;
using Ex02;

namespace ReversedTicTacToe
{
    public partial class SettingsForm : Form
    {
        private GameSettings m_Settings;
        private ePlayerType m_Player2Type = ePlayerType.CPU;
        private bool m_startGame = false;

        public GameSettings GameSettings
        {
            get { return m_Settings; }
        }

        public ePlayerType Player2Type
        {
            get { return m_Player2Type; }
        }

        public bool StartGame
        {
            get { return m_startGame; }
        }

        public GameSettings Settings { get; }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (validateNamesLegal())
            {
                string[] playersNames = { this.player1Name.Text, this.player2Name.Text };
                ePlayerType[] playersType = { ePlayerType.User, Player2Type };
                int boardSize = (int)this.numberOfRows.Value;
                m_Settings = new GameSettings(playersNames, playersType, boardSize);
                m_startGame = true;
                this.Close();
            }
        }

        private bool validateNamesLegal()
        {
            bool returnedValue = true;
            if (String.IsNullOrWhiteSpace(this.player1Name.Text))
            {
                returnedValue = false;
                this.player1Name.BackColor = Color.Yellow;
            }
            if (String.IsNullOrWhiteSpace(this.player2Name.Text))
            {
                returnedValue = false;
                this.player2Name.BackColor = Color.Yellow;
            }

            return returnedValue;
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
                m_Player2Type = ePlayerType.User;
            }
            else
            {
                this.player2Name.Text = "[Computer]";
                this.player2Name.BackColor = Color.Silver;
                m_Player2Type = ePlayerType.CPU;
            }
        }

        private void columnsOrRows_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown columnOrRow = sender as NumericUpDown;

            if (columnOrRow == this.numberOfRows)
            {
                this.numberOfColumns.Value = columnOrRow.Value;
            }
            else
            {
                this.numberOfRows.Value = columnOrRow.Value;
            }
        }

        private void playerName_Enter(object sender, EventArgs e)
        {
            TextBox playerTextBox = sender as TextBox;

            if (playerTextBox.BackColor == Color.Yellow)
            {
                playerTextBox.BackColor = Color.White;
            }
        }
    }
}
