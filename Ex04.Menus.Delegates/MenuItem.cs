namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        private MenuItem m_ParentMenuItem;
        private string m_Title;

        protected MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public MenuItem ParentMenuItem
        {
            get
            {
                return m_ParentMenuItem;
            }

            set
            {
                m_ParentMenuItem = value;
            }
        }

        public string Title
        {
            get
            {
                return m_Title;
            }

            set
            {
                m_Title = value;
            }
        }

        public abstract void Show();
    }
}