using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    class MenuTest : ISelectedListener
    {
        public void RunTest()
        {
            MainMenu interfaceMenu = new MainMenu();
            Ex04.Menus.Events.MainMenu eventsMenu = new Ex04.Menus.Events.MainMenu();

            interfaceMenu.ShowMenu();
            eventsMenu.ShowMenu();
        }

        private void createInterfaceMenu()
        {
            
        }

        private void createDelegateMenu()
        {
        }

        private void printDate()
        {
            Console.WriteLine(string.Format("Today Is: {0}", DateTime.Now.ToString("ddd dd/MM/yy")));
        }

        private void printTime()
        {
            Console.WriteLine(string.Format("The Time Is: {0}", DateTime.Now.ToString("HH:mm:ss")));
        }

        private void printVersionInfo()
        {
            Console.WriteLine("App Version: 23.2.4.9805");
        }

        private void countCapitals() 
        {
            string userInput;

            Console.Write("Please Enter A String: ");
            userInput = Console.ReadLine();
            Console.WriteLine(string.Format("Your String Has {0} Capital Letters", countCapitalsInString(userInput)));
        }
        
        private int countCapitalsInString(string i_StringToCount)
        {
            int capitalsCounter = 0;

            foreach(char character in i_StringToCount)
            {
                if (char.IsUpper(character))
                {
                    capitalsCounter++;
                }
            }

            return capitalsCounter;
        }

        public void NotifySelected(MenuItem i_SelectedMenuItem)
        {
            throw new NotImplementedException();
        }
    }
}
