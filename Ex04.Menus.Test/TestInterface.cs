namespace Ex04.Menus.Test
{
    using Ex04.Menus.Interfaces;

    public class TestInterface : IActionReporter
    {
        private MainMenu m_MainMenu;

        public TestInterface()
        {
            m_MainMenu = new MainMenu(MenuStrings.k_MainMenu + " Interfaces", MainMenu.eMenuType.MainMenu, 2);
        }

        public void ReportExecutingAction(IAction i_Action)
        {
            i_Action.DoAction();
        }

        public void Run()
        {
            buildMenu();
            m_MainMenu.Show();
        }

        private void buildMenu()
        {
            MainMenu subMenuVersionAndCapitals, subMenuDateTime;

            subMenuVersionAndCapitals = createSubMenu(MenuStrings.k_VersionAndCapitals, 2, m_MainMenu);
            subMenuDateTime = createSubMenu(MenuStrings.k_ShowDateOrTime, 2, m_MainMenu);
            createAction(new DisplayVersion(), MenuStrings.k_DisplayVersion, subMenuVersionAndCapitals);
            createAction(new CountCapitals(), MenuStrings.k_CountCapitals, subMenuVersionAndCapitals);
            createAction(new ShowTime(), MenuStrings.k_ShowTime, subMenuDateTime);
            createAction(new ShowDate(), MenuStrings.k_ShowDate, subMenuDateTime);
        }

        private void createAction(IAction i_Action, string i_Title, MainMenu i_ParentMenu)
        {
            MenuAction action = new MenuAction(i_Action, i_Title);
            i_ParentMenu.AddMenuItem(action);
            action.AttachReporter(this as IActionReporter);
        }

        private MainMenu createSubMenu(string i_Title, int i_SubMenusAmount, MainMenu i_ParentMenu)
        {
            MainMenu subMenu = new MainMenu(i_Title, MainMenu.eMenuType.SubMenu, i_SubMenusAmount);
            i_ParentMenu.AddMenuItem(subMenu);

            return subMenu;
        }
    }
}