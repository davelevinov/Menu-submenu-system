using System;

namespace Ex04.Menus.Delegates
{
    public delegate void ActionNotifierDelegate();

    public class MenuAction : MenuItem
    {
        public MenuAction(string i_Title) : base(i_Title)
        {
        }

        public event ActionNotifierDelegate ActionDone;

        public override void Show()
        {
            Console.Clear();
            onActionDone();
        }

        protected virtual void onActionDone()
        {
            if (ActionDone != null)
            {
                ActionDone.Invoke();
            }
        }
    }
}