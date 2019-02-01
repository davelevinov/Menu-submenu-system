namespace Ex04.Menus.Test
{
    using System;
    using Ex04.Menus.Interfaces;

    public class ShowTime : IAction
    {
        public void DoAction()
        {
            DateTime time = DateTime.Now;

            Console.WriteLine("The time now is: {0}:{1}:{2}", time.Hour, time.Minute, time.Second);
        }
    }
}