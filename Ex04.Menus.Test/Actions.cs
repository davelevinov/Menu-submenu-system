namespace Ex04.Menus.Test
{
    using System;

    public static class Actions
    {
        public static string GetUserInput()
        {
            string input;

            Console.WriteLine("Please enter a sentence:");
            input = Console.ReadLine();
            return input;
        }
    }
}