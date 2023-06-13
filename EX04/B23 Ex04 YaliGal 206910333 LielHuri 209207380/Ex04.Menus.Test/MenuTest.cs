namespace Ex04.Menus.Test
{
    public class MenuTest
    {
        public void RunTest()
        {
            Events.MainMenu eventsMenu = createDelegateMenu();
            Interfaces.MainMenu interfaceMenu = createInterfaceMenu();
            
            eventsMenu.ShowMenu();
            interfaceMenu.ShowMenu();
        }

        private static Interfaces.MainMenu createInterfaceMenu()
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
            dateMenuItem.AddSelectedListener(new ShowDateItemListener());
            timeMenuItem.AddSelectedListener(new ShowTimeItemListener());
            versionMenuItem.AddSelectedListener(new VersionInfoItemListener());
            countCapitalsMenuItem.AddSelectedListener(new CountCapitalsItemListener());

            return interfaceMainMenu;
        }

        private static Events.MainMenu createDelegateMenu()
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
            dateMenuItem.Selected += printDate;
            timeMenuItem.Selected += printTime;
            versionMenuItem.Selected += printVersionInfo;
            countCapitalsMenuItem.Selected += countCapitals;

            return eventsMainMenu;
        }

        private static void printDate(Events.MenuItem i_Invoker)
        {
            TestOperations.PrintCurrentDate();
        }

        private static void printTime(Events.MenuItem i_Invoker)
        {
            TestOperations.PrintCurrentTime();
        }

        private static void printVersionInfo(Events.MenuItem i_Invoker)
        {
            TestOperations.PrintVersionInfo();
        }

        private static void countCapitals(Events.MenuItem i_Invoker)
        {
            TestOperations.CountCapitals();
        }
    }
}
