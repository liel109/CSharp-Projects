using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class VersionInfoItemListener : ISelectedListener
    {
        public void NotifySelected(MenuItem i_SelectedMenuItem)
        {
            TestOperations.PrintVersionInfo();
        }
    }
}