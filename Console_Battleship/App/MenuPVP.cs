using System;
using Console_Battleship.Class;
using Console_Battleship.Global;

namespace Console_Battleship.App
{
    public static class MenuPVP
    {
        public static void startScreen()
        {
            welcomeScreen();

            Player player1 = setupPlayer(1);
            Player player2 = setupPlayer(2);

            Console.Clear();
            Console.WriteLine("Players: " + player1.PlayerName + " and " + player2.PlayerName);
            GlobalMethods.PauseConsoleWithoutStringParameter();
        }

        private static void welcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome to 2 player battleship!");

            GlobalMethods.PauseConsoleWithoutStringParameter();
            Console.Clear();
        }

        private static Player setupPlayer(int playerOrder)
        {
            Console.Clear();
            Console.WriteLine("Hello Player " + playerOrder.ToString());
            string input = Global.GlobalMethods.takeStringInput("Please enter your name: ");

            return new Player
            {
                PlayerName = input,
                PlayerOrder = playerOrder
            };
        }
    }
}
