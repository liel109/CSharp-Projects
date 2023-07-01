using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReversedTicTacToe
{
    public partial class MainGameForm : Form
    {
        private const int k_TopMargin = 7;
        private const int k_LeftMargin = 7;
        private const int k_ButtonWidth = 50;
        private const int k_LabelHeight = 20;
        private const int k_NameWidth = 65;
        private const int k_ScoreWidth = 10;
        private const int k_WidthBetweenPlayers = 10;
        private const int k_LabelTopMargin = 10;

        public MainGameForm(GameSettings i_GameSettings)
        {
            int boardSize = i_GameSettings.BoardSize;
            string[] playersNames = i_GameSettings.PlayersNames;
            int formWidth = k_LeftMargin * (boardSize + 1) + boardSize * k_ButtonWidth;
            int formHeight = formWidth + k_LabelHeight + k_LabelTopMargin;
            int labelLeftMargin = (formWidth - (k_NameWidth * 2) - (k_ScoreWidth * 2) - k_WidthBetweenPlayers) / 2;
            int labelTopMargin = formHeight - k_LabelHeight - k_LabelTopMargin;
            Label firstPlayerLabel = new Label();
            Label secondPlayerLabel = new Label();
            Label firstPlayerScoreLabel = new Label();
            Label secondPlayerScoreLabel = new Label();

            this.ClientSize = new Size(formWidth, formHeight);
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Button newButton = new Button();

                    newButton.Width = k_ButtonWidth;
                    newButton.Height = k_ButtonWidth;
                    newButton.Top = k_TopMargin + (k_TopMargin + k_ButtonWidth) * i;
                    newButton.Left = k_LeftMargin + (k_LeftMargin + k_ButtonWidth) * j;
                    newButton.Name = (i * boardSize + j).ToString();
                    this.Controls.Add(newButton);
                }
            }

            firstPlayerLabel.Width = k_NameWidth;
            firstPlayerLabel.Height = k_LabelHeight;
            firstPlayerLabel.Left = labelLeftMargin;
            firstPlayerLabel.Top = labelTopMargin;
            firstPlayerLabel.Text = $"{playersNames[0]}:";
            firstPlayerLabel.TextAlign = ContentAlignment.TopCenter;

            firstPlayerScoreLabel.Width = k_ScoreWidth;
            firstPlayerScoreLabel.Height = k_LabelHeight;
            firstPlayerScoreLabel.Left = labelLeftMargin + k_NameWidth;
            firstPlayerScoreLabel.Top = labelTopMargin;
            firstPlayerScoreLabel.Text = "0";
            firstPlayerScoreLabel.TextAlign = ContentAlignment.TopCenter;

            secondPlayerLabel.Width = k_NameWidth;
            secondPlayerLabel.Height = k_LabelHeight;
            secondPlayerLabel.Left = labelLeftMargin + k_NameWidth + k_ScoreWidth + k_WidthBetweenPlayers;
            secondPlayerLabel.Top = labelTopMargin;
            secondPlayerLabel.Text = $"{playersNames[1]}:";
            secondPlayerLabel.TextAlign = ContentAlignment.TopCenter;

            secondPlayerScoreLabel.Width = k_ScoreWidth;
            secondPlayerScoreLabel.Height = k_LabelHeight;
            secondPlayerScoreLabel.Left = labelLeftMargin + (k_NameWidth * 2) + k_ScoreWidth + k_WidthBetweenPlayers;
            secondPlayerScoreLabel.Top = labelTopMargin;
            secondPlayerScoreLabel.Text = "0";
            secondPlayerScoreLabel.TextAlign = ContentAlignment.TopCenter;

            this.Controls.AddRange(new Control[4] { firstPlayerLabel, firstPlayerScoreLabel, secondPlayerLabel, secondPlayerScoreLabel });
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
