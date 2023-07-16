using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ex02;

namespace ReversedTicTacToe
{
    public partial class MainGameForm : Form
    {
        private const int k_TopMargin = 7;
        private const int k_LeftMargin = 7;
        private const int k_ButtonWidth = 50;
        private const int k_WidthBetweenPlayers = 10;
        private const int k_LabelTopMargin = 10;
        private const int k_ScoreLeftMargin = 5;
        private const string k_PlayerOneMark = "X";
        private const string k_PlayerTwoMark = "O";
        private const string k_WinningMessage = "The winner is {0}!";
        private const string k_TieMessage = "Tie!";

        private readonly Button[,] r_GameBoard;
        private readonly int r_BoardSize;
        private readonly string[] r_PlayersNames;
        private readonly Game r_Game;

        public MainGameForm(GameSettings i_GameSettings)
        {
            InitializeComponent();

            r_BoardSize = i_GameSettings.BoardSize;
            r_GameBoard = new Button[r_BoardSize, r_BoardSize];
            r_PlayersNames = i_GameSettings.PlayersNames;
            r_Game = new Game(i_GameSettings.BoardSize, i_GameSettings.PlayerTypes[1]);
            r_Game.GameFinished += Game_EndGame;
            r_Game.BoardChanged += Game_MoveOccured;

            int formWidth = k_LeftMargin * (r_BoardSize + 1) + r_BoardSize * k_ButtonWidth;
            int formHeight = formWidth + playerOneLabel.Height + k_LabelTopMargin;
            int labelLeftMargin = (formWidth - (playerOneLabel.Width + playerTwoLabel.Width) - (playerOneScore.Width * 2) - k_WidthBetweenPlayers) / 2;
            int labelTopMargin = formHeight - playerOneLabel.Height - k_LabelTopMargin;

            ClientSize = new Size(formWidth, formHeight);
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    Button newButton = new Button();

                    newButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)(0));
                    newButton.Width = k_ButtonWidth;
                    newButton.Height = k_ButtonWidth;
                    newButton.Top = k_TopMargin + (k_TopMargin + k_ButtonWidth) * i;
                    newButton.Left = k_LeftMargin + (k_LeftMargin + k_ButtonWidth) * j;
                    newButton.Name = (i * r_BoardSize + j).ToString();
                    newButton.Click += Button_OnClick;
                    r_GameBoard[i, j] = newButton;
                    this.Controls.Add(newButton);
                }
            }

            playerOneLabel.Left = labelLeftMargin;
            playerOneLabel.Top = labelTopMargin;
            playerOneLabel.Text = $"{r_PlayersNames[0]}:";

            playerOneScore.Left = labelLeftMargin + playerOneLabel.Width + k_ScoreLeftMargin;
            playerOneScore.Top = labelTopMargin;

            playerTwoLabel.Left = labelLeftMargin + playerOneLabel.Width + playerOneScore.Width + k_WidthBetweenPlayers;
            playerTwoLabel.Top = labelTopMargin;
            playerTwoLabel.Text = $"{r_PlayersNames[1]}:";

            playerTwoScore.Left = labelLeftMargin + playerOneLabel.Width + playerTwoLabel.Width +
                playerOneScore.Width + k_WidthBetweenPlayers + k_ScoreLeftMargin;
            playerTwoScore.Top = labelTopMargin;
        }

        private void Game_MoveOccured((int, int) i_UpdatedCoordinate)
        {
            updateCell(i_UpdatedCoordinate);
            changePlayerFocus();
        }

        private void Game_EndGame(ePlayerMark i_Winner)
        {
            if (i_Winner != ePlayerMark.None)
            {
                updateScore(i_Winner, r_Game.Players);
            }

            if (showEndDialog(i_Winner) == DialogResult.Yes)
            {
                resetBoard();
            }
            else
            {
                this.Close();
            }
        }

        private void changePlayerFocus()
        {
            if (r_Game.MovesCounter % 2 == 0)
            {
                playerOneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0));
                playerTwoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)(0));
            }
            else
            {
                playerOneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)(0));
                playerTwoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0));
            }
        }

        private void updateCell((int, int) i_Coordinate)
        {
            Button buttonToUpdate = r_GameBoard[i_Coordinate.Item1, i_Coordinate.Item2];
            string currentPlayerMark;

            if (r_Game.MovesCounter % 2 == 0)
            {
                currentPlayerMark = k_PlayerTwoMark;
            }
            else
            {
                currentPlayerMark = k_PlayerOneMark;
            }

            buttonToUpdate.Text = currentPlayerMark;
            buttonToUpdate.Enabled = false;
        }

        private DialogResult showEndDialog(ePlayerMark i_Winner) 
        {
            string userMessage;
            string scoreResult;
            string title;
            string anotherGameStr = "Would you like to play another round?";

            switch (i_Winner)
            {
                case ePlayerMark.Player1:
                    scoreResult = string.Format(k_WinningMessage, r_PlayersNames[0]);
                    title = "A Win!";
                    break;
                case ePlayerMark.Player2:
                    scoreResult = string.Format(k_WinningMessage, r_PlayersNames[1]);
                    title = "A Win!";
                    break;
                default:
                    scoreResult = k_TieMessage;
                    title = "A Tie!";
                    break;
            }

            userMessage = string.Format(@"{0}
{1}", scoreResult, anotherGameStr);
            return MessageBox.Show(userMessage, title, MessageBoxButtons.YesNo);
        }

        private void resetBoard()
        {
            foreach (Button cellButton in r_GameBoard)
            {
                cellButton.Text = string.Empty;
                cellButton.Enabled = true;
            }

            r_Game.ResetGame();
            changePlayerFocus();
        }

        private void updateScore(ePlayerMark i_Winner, Player[] i_Players)
        {
            switch (i_Winner)
            {
                case ePlayerMark.Player1:
                    playerTwoScore.Text = i_Players[0].Score.ToString();
                    break;
                case ePlayerMark.Player2:
                    playerTwoScore.Text = i_Players[1].Score.ToString();
                    break;
            }
        }

        private void Button_OnClick(object sender, EventArgs e) // *****************************
        {
            Button clickedButton = sender as Button;
            string markToUpdate = string.Empty;

            switch (r_Game.getCurrentPlayer().Mark)
            {
                case ePlayerMark.Player1:
                    markToUpdate = k_PlayerOneMark;
                    break;
                case ePlayerMark.Player2:
                    markToUpdate = k_PlayerTwoMark;
                    break;
            }

            clickedButton.Text = markToUpdate;
            clickedButton.Enabled = false;
            r_Game.DoNextGameMove(parseCoordinate(clickedButton.Name));
        }

        private (int, int) parseCoordinate(string i_ButtonIndexString)
        {
            int buttonIndex = int.Parse(i_ButtonIndexString);

            return (buttonIndex / r_BoardSize, buttonIndex % r_BoardSize);
        }
    }
}
