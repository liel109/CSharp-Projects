using System;
using System.Windows.Forms;

namespace ReversedTicTacToe
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameRunner.RunGame();
        }
    }
}
