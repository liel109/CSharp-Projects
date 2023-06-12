using System;
using System.Collections.Generic;
using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            MainMenu main = new MainMenu();
            Console.WriteLine(string.Format("Today Is {0}", DateTime.Now.ToString("dddd, dd/MM/yy")));

            //main.TestMainMenu();
            Console.ReadLine();
        }
    }
}
