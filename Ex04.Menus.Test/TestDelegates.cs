namespace Ex04.Menus.Test
{
    using Ex04.Menus.Delegates;

    public class TestDelegates
    {
        private MainMenu m_MainMenu;
        
        public TestDelegates()
        {
            m_MainMenu = new MainMenu(MenuStrings.k_MainMenu + " Delegates", MainMenu.eMenuType.MainMenu, 2);
        }

        public void Run()
        {
            buildMenu();
            m_MainMenu.Show();
        }

        private void buildMenu()
        {
            MainMenu subMenuVersionAndCapitals = createSubMenu(MenuStrings.k_VersionAndCapitals, 2, m_MainMenu);
            MainMenu subMenuDateTime = createSubMenu(MenuStrings.k_ShowDateOrTime, 2, m_MainMenu);

            MenuAction displayVersion = createAction(MenuStrings.k_DisplayVersion, subMenuVersionAndCapitals);
            MenuAction countCapitals = createAction(MenuStrings.k_CountCapitals, subMenuVersionAndCapitals);
            MenuAction showTime = createAction(MenuStrings.k_ShowTime, subMenuDateTime);
            MenuAction showDate = createAction(MenuStrings.k_ShowDate, subMenuDateTime);

            displayVersion.ActionDone += new DisplayVersion().DoAction;
            countCapitals.ActionDone += new CountCapitals().DoAction;
            showTime.ActionDone += new ShowTime().DoAction;
            showDate.ActionDone += new ShowDate().DoAction;
        }

        private MenuAction createAction(string i_Title, MainMenu i_ParentMenu)
        {
            MenuAction action = new MenuAction(i_Title);
            i_ParentMenu.AddMenuItem(action);

            return action;
        }

        private MainMenu createSubMenu(string i_Title, int i_SubMenusAmount, MainMenu i_ParentMenu)
        {
            MainMenu sub = new MainMenu(i_Title, MainMenu.eMenuType.SubMenu, i_SubMenusAmount);
            i_ParentMenu.AddMenuItem(sub);

            return sub;
        }
    }
}