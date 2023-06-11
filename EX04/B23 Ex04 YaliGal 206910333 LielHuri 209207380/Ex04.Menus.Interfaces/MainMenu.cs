using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly MenuItem r_MainMenuItem;
        private readonly Stack<MenuItem> r_MenuStack;

        public MenuItem MainMenuItem
        {
            get { return r_MainMenuItem; }
        }

        public MainMenu()
        {
            
        }

        public void ShowMenu()
        {

        }
    }
}
