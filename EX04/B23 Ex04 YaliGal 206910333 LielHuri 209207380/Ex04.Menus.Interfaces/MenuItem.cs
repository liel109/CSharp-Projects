using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly List<ISelectedListener> r_SelectedListeners = new List<ISelectedListener>();
        private string m_Title;
        private List<MenuItem> m_SubMenuItems;

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public int SubMenuItemsCount
        {
            get
            {
                int numberOfItems;

                if (m_SubMenuItems == null)
                {
                    numberOfItems = 0;
                }
                else
                {
                    numberOfItems = m_SubMenuItems.Count;
                }

                return numberOfItems;
            }
        }

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public void AddSelectedListener(ISelectedListener i_ListenerToAdd)
        {
            r_SelectedListeners.Add(i_ListenerToAdd);
        }

        public void RemoveSelectedListener(ISelectedListener i_ListenerToRemove)
        {
            r_SelectedListeners.Remove(i_ListenerToRemove);
        }

        public void AddSubMenuItem(MenuItem i_MenuItemToAdd)
        {
            if (m_SubMenuItems == null)
            {
                m_SubMenuItems = new List<MenuItem>();
            }

            m_SubMenuItems.Add(i_MenuItemToAdd);
        }

        public void AddSubMenuItem(string i_NewSubMenuItemTitle)
        {
            MenuItem itemToAdd = new MenuItem(i_NewSubMenuItemTitle);

            AddSubMenuItem(itemToAdd);
        }

        public bool RemoveSubMenuItem(MenuItem i_MenuItemToAdd)
        {
            return m_SubMenuItems.Remove(i_MenuItemToAdd);
        }

        public bool RemoveSubMenuItem(string i_NewSubMenuItemTitle)
        {
            MenuItem itemToAdd = new MenuItem(i_NewSubMenuItemTitle);

            return RemoveSubMenuItem(itemToAdd);
        }

        public MenuItem[] GetSubMenuItems()
        {
            return m_SubMenuItems.ToArray();
        }

        public MenuItem GetMenuItemByTitle(string i_RequestedMenuItemTitle)
        {
            MenuItem itemToReturn = null;

            foreach (MenuItem menuItem in m_SubMenuItems)
            {
                if (menuItem.Title == i_RequestedMenuItemTitle)
                {
                    itemToReturn = menuItem;
                    break;
                }
            }

            return itemToReturn;
        }

        public MenuItem GetSubMenuItemByIndex(int i_IndexOfSubMenuItem)
        {
            return m_SubMenuItems[i_IndexOfSubMenuItem];
        }

        internal void SelectedByUser()
        {
            onSelected();
        }

        private void onSelected()
        {
            foreach (ISelectedListener listener in r_SelectedListeners)
            {
                listener.NotifySelected(this);
            }
        }
    }
}
