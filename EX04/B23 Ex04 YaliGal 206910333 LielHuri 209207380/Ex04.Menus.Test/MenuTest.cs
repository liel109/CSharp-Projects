using Ex04.Menus;
using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    class MenuTest : Interfaces.ISelectedListener
    {
        public void RunTest()
        {
            Events.MainMenu eventsMenu = createDelegateMenu();
            Interfaces.MainMenu interfaceMenu = createInterfaceMenu();
            
            eventsMenu.ShowMenu();
            interfaceMenu.ShowMenu();
        }

        private Interfaces.MainMenu createInterfaceMenu()
        {
            Interfaces.MainMenu interfaceMainMenu = new Interfaces.MainMenu();
            Interfaces.MenuItem dateAndTimeMenuItem = new Interfaces.MenuItem("Show Date/Time");
            Interfaces.MenuItem versionAndCapitalsMenuItem = new Interfaces.MenuItem("Version and Capitals");
            Interfaces.MenuItem dateMenuItem = new Interfaces.MenuItem("Show Date");
            Interfaces.MenuItem timeMenuItem = new Interfaces.MenuItem("Show Time");
            Interfaces.MenuItem versionMenuItem = new Interfaces.MenuItem("Show Version");
            Interfaces.MenuItem countCapitalsMenuItem = new Interfaces.MenuItem("Count Capitals");

            interfaceMainMenu.MainMenuItem.AddSubMenuItem(dateAndTimeMenuItem);
            interfaceMainMenu.MainMenuItem.AddSubMenuItem(versionAndCapitalsMenuItem);
            dateAndTimeMenuItem.AddSubMenuItem(dateMenuItem);
            dateAndTimeMenuItem.AddSubMenuItem(timeMenuItem);
            versionAndCapitalsMenuItem.AddSubMenuItem(versionMenuItem);
            versionAndCapitalsMenuItem.AddSubMenuItem(countCapitalsMenuItem);
            dateMenuItem.AddSelectedListener(this as ISelectedListener);
            timeMenuItem.AddSelectedListener(this as ISelectedListener);
            versionMenuItem.AddSelectedListener(this as ISelectedListener);
            countCapitalsMenuItem.AddSelectedListener(this as ISelectedListener);

            return interfaceMainMenu;
        }

        private Events.MainMenu createDelegateMenu()
        {
            Events.MainMenu eventsMainMenu = new Events.MainMenu();

            Events.MenuItem dateAndTimeMenuItem = new Events.MenuItem("Show Date/Time");
            Events.MenuItem versionAndCapitalsMenuItem = new Events.MenuItem("Version and Capitals");
            Events.MenuItem dateMenuItem = new Events.MenuItem("Show Date");
            Events.MenuItem timeMenuItem = new Events.MenuItem("Show Time");
            Events.MenuItem versionMenuItem = new Events.MenuItem("Show Version");
            Events.MenuItem countCapitalsMenuItem = new Events.MenuItem("Count Capitals");

            eventsMainMenu.MainMenuItem.AddSubMenuItem(dateAndTimeMenuItem);
            eventsMainMenu.MainMenuItem.AddSubMenuItem(versionAndCapitalsMenuItem);
            dateAndTimeMenuItem.AddSubMenuItem(dateMenuItem);
            dateAndTimeMenuItem.AddSubMenuItem(timeMenuItem);
            versionAndCapitalsMenuItem.AddSubMenuItem(versionMenuItem);
            versionAndCapitalsMenuItem.AddSubMenuItem(countCapitalsMenuItem);
            dateMenuItem.Selected += this.printDate;
            timeMenuItem.Selected += this.printTime;
            versionMenuItem.Selected += this.printVersionInfo;
            countCapitalsMenuItem.Selected += this.countCapitals;

            return eventsMainMenu;
        }

        private void printDate()
        {
            Console.WriteLine(string.Format("Today Is: {0}", DateTime.Now.ToString("ddd dd/MM/yy")));
        }

        private void printDate(Interfaces.MenuItem i_Invoker)
        {
            printDate();
        }

        private void printDate(Events.MenuItem i_Invoker)
        {
            printDate();
        }

        private void printTime()
        {
            Console.WriteLine(string.Format("The Time Is: {0}", DateTime.Now.ToString("HH:mm:ss")));
        }

        private void printTime(Interfaces.MenuItem i_Invoker)
        {
            printTime();
        }

        private void printTime(Events.MenuItem i_Invoker)
        {
            printTime();
        }

        private void printVersionInfo()
        {
            Console.WriteLine("App Version: 23.2.4.9805");
        }

        private void printVersionInfo(Interfaces.MenuItem i_Invoker)
        {
            printVersionInfo();
        }

        private void printVersionInfo(Events.MenuItem i_Invoker)
        {
            printVersionInfo();
        }

        private void countCapitals() 
        {
            string userInput;

            Console.Write("Please Enter A String: ");
            userInput = Console.ReadLine();
            Console.WriteLine(string.Format("Your String Has {0} Capital Letters", countCapitalsInString(userInput)));
        }

        private void countCapitals(Interfaces.MenuItem i_Invoker)
        {
            countCapitals();
        }

        private void countCapitals(Events.MenuItem i_Invoker)
        {
            countCapitals();
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
            switch (i_SelectedMenuItem.Title)
            {
                case "Show Date":
                    printDate();
                    break;

                case "Show Time":
                    printTime();
                    break;

                case "Show Version":
                    printVersionInfo();
                    break;

                case "Count Capitals":
                    countCapitals();
                    break;
            }
        }

    }
}
