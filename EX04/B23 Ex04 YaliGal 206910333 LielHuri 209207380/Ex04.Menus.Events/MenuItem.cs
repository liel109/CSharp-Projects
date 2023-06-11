using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private string m_Title;
        private readonly List<MenuItem> r_SubMenuItems = new List<MenuItem>();
        public event Action<MenuItem> Selected;

        public string Title
        {
            get { return m_Title; }
        }

        public List<MenuItem> SubMenuItems
        {
            get { return r_SubMenuItems; }
        }

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public void AddSubMenuItem(MenuItem i_MenuItemToAdd)
        {
            r_SubMenuItems.Add(i_MenuItemToAdd);
        }

        public void AddSubMenuItem(string i_NewSubMenuItemTitle)
        {
            MenuItem itemToAdd = new MenuItem(i_NewSubMenuItemTitle);
            AddSubMenuItem(itemToAdd);
        }
        public void RemoveSubMenuItem(MenuItem i_MenuItemToAdd)
        {
            r_SubMenuItems.Remove(i_MenuItemToAdd);
        }

        public void RemoveSubMenuItem(string i_NewSubMenuItemTitle)
        {
            MenuItem itemToAdd = new MenuItem(i_NewSubMenuItemTitle);
            RemoveSubMenuItem(itemToAdd);
        }

        public MenuItem GetMenuItemByTitle(string i_RequestedMenuItemTitle)
        {
            MenuItem itemToReturn = null;

            foreach(MenuItem menuItem in r_SubMenuItems)
            {
                if (menuItem.Title == i_RequestedMenuItemTitle)
                {
                    itemToReturn = menuItem;
                    break;
                }
            }

            return itemToReturn;
        }

        internal void SelectedByUser()
        {
            OnSelected();
        }

        protected virtual void OnSelected()
        {
            if(Selected != null)
            {
                Selected.Invoke(this);
            }
        }
    }
}
