namespace Ex04.Menus.Test
{
    using System;
    using Ex04.Menus.Interfaces;

    public class ShowDate : IAction
    {
        public void DoAction()
        {
            DateTime time = DateTime.Now;

            Console.WriteLine("The date today is: {0}/{1}/{2}", time.Day, time.Month, time.Year);
        }
    }
}