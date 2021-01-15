using System;
namespace Console_Battleship.Global
{
    public static class GlobalMethods
    {
        public static void PauseConsoleWithStringParameter(string outputString)
        {
            PauseConsole(outputString);
        }
        public static void PauseConsoleWithoutStringParameter()
        {
            PauseConsole("Press any key to continue...");
        }
        private static void PauseConsole(string outputString)
        {
            Console.WriteLine();
            Console.WriteLine(outputString);
            Console.ReadKey();
        }
    }
}
