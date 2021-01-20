using System;
using System.Collections.Generic;
using System.Linq;
using Console_Battleship.Class;
using Console_Battleship.Global;

namespace Console_Battleship.App
{
    public static class MenuPVP
    {
        public static void setupPVP()
        {
            welcomeScreen();

            Player player1 = setupPlayer(1);
            GlobalMethods.PauseConsoleWithStringParameter("Player " + player1.PlayerOrder.ToString() + " setup");
            Player player2 = setupPlayer(2);
            GlobalMethods.PauseConsoleWithStringParameter("Player " + player2.PlayerOrder.ToString() + " setup");

            Console.Clear();

            showPlayerSetupBoard(player1);

            //Player1 add pieces

            //Player2 add pieces

            //play game class call
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
            string input = GlobalMethods.takeStringInput("Please enter your name: ");

            return new Player
            {
                PlayerName = input,
                PlayerOrder = playerOrder
            };
        }
        public static void showPlayerSetupBoard(Player player)
        {
            List<Coordinate> playerShipCoordinates = GlobalMethods.getPlayerShipCoordinates(player);

            GlobalMethods.displayTopRow();
            for (int y = 0; y < StaticValues.Y_AXIS_SIZE; y++)
            {
                Console.Write("{0,4}", y.ToString());
                for (int x = 0; x < StaticValues.X_AXIS_SIZE; x++)
                {
                    if (playerShipCoordinates.Where(i => i.X_Axis == x && i.Y_Axis == y).Count() == 0)
                    {
                        Console.Write("{0,4}", "-");
                    }
                    else
                    {
                        Console.Write("{0,4}", "^");
                    }
                }
                Console.WriteLine();
            }

            //for breathing room
            Console.WriteLine();

            GlobalMethods.PauseConsoleWithoutStringParameter();
        }
    }
}

//player1.Ships.Add(new Ship
//{
//    ShipLocation = new List<Coordinate>
//                {
//                    new Coordinate
//                    {
//                        X_Axis = 1,
//                        Y_Axis = 1
//                    },
//                    new Coordinate
//                    {
//                        X_Axis = 1,
//                        Y_Axis = 2
//                    },
//                    new Coordinate
//                    {
//                        X_Axis = 1,
//                        Y_Axis = 3
//                    }
//                }
//});