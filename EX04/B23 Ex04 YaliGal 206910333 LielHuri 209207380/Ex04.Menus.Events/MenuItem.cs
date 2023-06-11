using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private string m_Title;
        private readonly List<MenuItem> r_SubMenuItems;
        public event Action<MenuItem> Selected;

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

        protected virtual void OnSelected()
        {
            if(Selected != null)
            {
                Selected.Invoke(this);
            }
        }
    }
}
