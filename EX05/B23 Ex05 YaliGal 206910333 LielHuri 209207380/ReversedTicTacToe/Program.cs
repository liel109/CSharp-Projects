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

            SettingsForm form = new SettingsForm();
            form.ShowDialog();
            form.GameSettings.printSettings();

            Console.ReadLine();

            //Application.Run(new GameSettings());
        }
    }
}
