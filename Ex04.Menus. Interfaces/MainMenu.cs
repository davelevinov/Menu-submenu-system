namespace Ex04.Menus.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MainMenu : MenuItem, IMainMenu
    {
        private const string k_Back = "Back";
        private const string k_Separator = "------------------------------------";
        private const string k_ChooseOption = "Please choose one of the options:";
        private const string k_Exit = "Exit";
        private const string k_ReturnToMain = "Press any key to return to menu...";
        private const string k_InvalidInput = "Invalid input, type in a number from the choices available";
        private const int k_UserQuitIndex = 0;
        private readonly List<MenuItem> m_MenuItems;
        private readonly eMenuType r_MenuType;
        private readonly string r_QuitString;

        public MainMenu(string i_Title, eMenuType i_MenuType, int i_SubMenusAmount)
            : base(i_Title)
        {
            m_MenuItems = new List<MenuItem>(i_SubMenusAmount);

            r_MenuType = i_MenuType;

            switch (i_MenuType)
            {
                case eMenuType.SubMenu:
                    r_QuitString = k_Back;
                    break;
                case eMenuType.MainMenu:
                    r_QuitString = k_Exit;
                    break;
            }
        }

        public enum eMenuType
        {
            MainMenu,
            SubMenu
        }

        private enum eMenuSession
        {
            Running,
            UserQuit
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            i_MenuItem.ParentMenuItem = this;
            m_MenuItems.Add(i_MenuItem);
        }

        public string GetInfoToShow()
        {
            int index = 1;
            StringBuilder layout = new StringBuilder();
            foreach (MenuItem item in m_MenuItems)
            {
                layout.AppendLine($"{index}) {item.Title}");
                ++index;
            }

            layout.AppendLine($"{k_UserQuitIndex}) {r_QuitString}");
            return layout.ToString();
        }

        public override void Show()
        {
            int userChoice;
            eMenuSession menuSession = eMenuSession.Running;

            do
            {
                Console.Clear();
                showTitle();
                Console.WriteLine(k_ChooseOption);
                Console.WriteLine(GetInfoToShow());
                userChoice = getValidUserInput();
                int trueIndex = userChoice - 1;

                if (userChoice == k_UserQuitIndex)
                {
                    menuSession = eMenuSession.UserQuit;
                }
                else
                {
                    handleMenuItem(trueIndex);
                }
            }
            while (menuSession != eMenuSession.UserQuit);
        }

        private int getValidUserInput()
        {
            bool validInput = false;
            int result;

            do
            {
                string input = Console.ReadLine();
                validInput = int.TryParse(input, out result)
                             && (result >= k_UserQuitIndex && result <= m_MenuItems.Count);

                if (!validInput)
                {
                    Console.WriteLine(k_InvalidInput);
                }
            }
            while (!validInput);

            return result;
        }

        private void handleMenuItem(int i_TrueIndex)
        {
            m_MenuItems[i_TrueIndex].Show();
            if (m_MenuItems[i_TrueIndex] is MenuAction)
            {
                Console.WriteLine(k_ReturnToMain);
                Console.ReadKey();
            }
        }

        private void showTitle()
        {
            Console.WriteLine(k_Separator);
            int spaceSize = (k_Separator.Length - Title.Length) / 2;
            for (int i = 0; i < spaceSize; i++)
            {
                Console.Write(' ');
            }

            Console.WriteLine(Title);
            Console.WriteLine(k_Separator);
        }
    }
}