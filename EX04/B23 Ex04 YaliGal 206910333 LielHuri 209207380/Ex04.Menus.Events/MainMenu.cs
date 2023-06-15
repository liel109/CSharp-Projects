using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly MenuItem r_MainMenuItem;
        private readonly Stack<MenuItem> r_MenuNavigationStack;

        public MenuItem MainMenuItem
        {
            get { return r_MainMenuItem; }
        }

        public MainMenu()
        {
            r_MainMenuItem = new MenuItem("Actions Main Menu");
            r_MenuNavigationStack = new Stack<MenuItem>();
        }

        public void ShowMenu()
        {
            r_MenuNavigationStack.Push(r_MainMenuItem);
            while (r_MenuNavigationStack.Any())
            {
                MenuItem currentItem = r_MenuNavigationStack.Peek();
                int userSelection;

                Console.Clear();
                userSelection = getUserSelection();
                if (userSelection == 0)
                {
                    r_MenuNavigationStack.Pop();
                }
                else
                {
                    MenuItem selectedItem = currentItem.GetSubMenuItemByIndex(userSelection - 1);
                    bool itemHasSubMenu = selectedItem.SubMenuItemsCount != 0;

                    selectedItem.SelectedByUser();
                    if (itemHasSubMenu)
                    {
                        r_MenuNavigationStack.Push(selectedItem);
                    }
                }
            }
        }

        private int getUserSelection()
        {
            MenuItem currentMenuComponent = r_MenuNavigationStack.Peek();
            string userSelection = null;
            bool isValidSelection = false;

            while (!isValidSelection)
            {
                printSelectionOptions(currentMenuComponent, r_MenuNavigationStack.Count);
                userSelection = Console.ReadLine();
                isValidSelection = isStringANumberInRange(userSelection, 0, currentMenuComponent.SubMenuItemsCount);
                if (!isValidSelection)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Select A Valid Option...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            int userSelectionInt = int.Parse(userSelection);

            return userSelectionInt;
        }

        private bool isStringANumberInRange(string i_String, int i_MinValue, int i_MaxValue)
        {
            int numericValueOfString;
            bool isNumeric = int.TryParse(i_String, out numericValueOfString);

            return isNumeric && (numericValueOfString >= i_MinValue && numericValueOfString <= i_MaxValue);
        }

        private void printSelectionOptions(MenuItem i_MenuItem, int i_MenuItemNavigationDepth)
        {
            string backOptionText;
            bool isRootMenu = i_MenuItemNavigationDepth == 1;
            StringBuilder optionsMenuBuilder = new StringBuilder();

            optionsMenuBuilder.AppendLine(string.Format(@"{0}. {1}:
=======================", i_MenuItemNavigationDepth, i_MenuItem.Title));
            for (int i = 0; i < i_MenuItem.SubMenuItemsCount; i++)
            {
                optionsMenuBuilder.AppendLine(string.Format("{0,3} - {1}", i + 1, i_MenuItem.GetSubMenuItemByIndex(i).Title));
            }

            if (isRootMenu)
            {
                backOptionText = "Exit";
            }
            else
            {
                backOptionText = "Return";
            }

            optionsMenuBuilder.Append(string.Format(@"  0 - {0}
=======================
Please enter your choice (1-{1} or 0 to {2}):", backOptionText, i_MenuItem.SubMenuItemsCount, backOptionText));
            Console.WriteLine(optionsMenuBuilder);
        }
    }
}
