using System;
using System.Windows.Forms;
using Ex02;

namespace ReversedTicTacToe
{
    public class GameRunner
    {
        public static void RunGame()
        {
            SettingsForm gameSettingsForm = new SettingsForm();
            MainGameForm mainGameForm;

            if (gameSettingsForm.ShowDialog() == DialogResult.OK)
            {
                GameSettings settings = gameSettingsForm.GameSettings;

                mainGameForm = new MainGameForm(settings);
                mainGameForm.ShowDialog();
            }
        }
    }
}
