using System;
using Console_Battleship.Global;

namespace Console_Battleship.App
{
    public static class MenuPVP
    {
        public static void startScreen()
        {
            welcomeScreen();
            //get player 1 info
            //get player 2 info
        }

        private static void welcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome to 2 player battleship!");

            GlobalMethods.PauseConsoleWithoutStringParameter();
            Console.Clear();
        }
    }
}
