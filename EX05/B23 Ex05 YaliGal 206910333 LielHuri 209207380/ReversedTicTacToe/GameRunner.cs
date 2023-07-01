using System;
using System.Windows.Forms;

namespace ReversedTicTacToe
{
    public class GameRunner
    {
        public static void RunGame()
        {
            SettingsForm gameSettingsForm = new SettingsForm();
            MainGameForm mainGameForm = new MainGameForm();

            gameSettingsForm.ShowDialog();
            setGameFormAttributes(mainGameForm, gameSettingsForm.Settings);
            mainGameForm.ShowDialog();
        }

        private static void setGameFormAttributes(MainGameForm i_MainForm, GameSettings i_Settings) 
        {
        }
    }
}
