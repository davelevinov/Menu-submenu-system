namespace Ex04.Menus.Test
{
    using System;
    using Ex04.Menus.Interfaces;

    public class CountCapitals : IAction
    {
        public void DoAction()
        {
            int inputLength;
            int result = 0;
            string userStringInput = Actions.GetUserInput();
            inputLength = userStringInput.Length;

            for (int i = 0; i < inputLength; i++)
            {
                if (char.IsUpper(userStringInput[i]))
                {
                    result++;
                }
            }

            Console.WriteLine("Your sentence contains {0} capital letters.", result);
        }
    }
}