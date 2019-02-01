namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            TestInterface mainMenuInterface = new TestInterface();
            mainMenuInterface.Run();

            TestDelegates mainMenuDelegates = new TestDelegates();
            mainMenuDelegates.Run();
        }
    }
}