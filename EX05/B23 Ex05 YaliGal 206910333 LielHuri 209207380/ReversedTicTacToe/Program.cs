using System;
using System.Windows.Forms;

namespace ReversedTicTacToe
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameRunner.RunGame();

            //Application.Run(new GameSettings());
        }
    }
}
