using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_Title;
        private readonly List<MenuItem> r_SubMenuItems;
        private readonly List<ISelectedListener> r_SelectedListeners = new List<ISelectedListener>();

        public string Title
        {
            get { return m_Title; }
        }

        public List<MenuItem> SubMenuItems
        {
            get { return r_SubMenuItems; }
        }

        public MenuItem()
        {
            
        }

        public void AddSelectedListener(ISelectedListener i_ListenerToAdd)
        {

        }

        public void RemoveSelectedListener(ISelectedListener i_ListenerToRemove)
        {

        }

        public void AddSubMenuItem(MenuItem i_MenuItemToAdd)
        {

        }

        public void AddSubMenuItem(string i_NewSubMenuItemTitle)
        {

        }

        public MenuItem GetMenuItemByTitle(string i_RequestedMenuItemTitle)
        {
            return null;
        }

        internal void SelectedByUser()
        {

        }

        private void OnSelected()
        {
        }
    }
}
