using System;
using System.Collections.Generic;
using Console_Battleship.Class;

namespace Console_Battleship.Global
{
    public static class GlobalMethods
    {
        public static void PauseConsoleWithStringParameter(string outputString)
        {
            Console.WriteLine(outputString);
            PauseConsole();
        }
        public static void PauseConsoleWithoutStringParameter()
        {
            PauseConsole();
        }
        private static void PauseConsole()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static int takeNumericInput(string displayString, List<int> allowableValues = null)
        {
            int? numericInput = null;
            while (!numericInput.HasValue)
            {
                int tempValue = 0;
                Console.Write(displayString);
                string input = Console.ReadLine();
                if (int.TryParse(input, out tempValue))
                {
                    if(allowableValues.Count > 0)
                    {
                        if (isValidOption(tempValue, allowableValues))
                        {
                            numericInput = tempValue;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a VALID option");
                        }
                    }
                    else
                    {
                        numericInput = tempValue;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a NUMBER shown above");
                }
            }
            return numericInput.Value;
        }
        private static bool isValidOption(int numericInput, List<int> allowableValues) 
        {
            return allowableValues.Contains(numericInput);
        }
        public static string takeStringInput(string displayString)
        {
            Console.Write(displayString);
            string input = Console.ReadLine();
            return input;
        }
        public static void showPlayerGameBoard(Player player)
        {

        }
        public static void displayTopRow()
        {
            //extra space needed to bump the top row correctly
            Console.Write("{0,4}", " ");

            for(int i = 0; i < StaticValues.X_AXIS_SIZE; i++)
            {
                Console.Write("{0,4}", i.ToString());
            }
            Console.WriteLine();
        }
        public static List<Coordinate> getPlayerShipCoordinates(Player player)
        {
            List<Coordinate> shipCoordinates = new List<Coordinate>();

            foreach(Ship ship in player.Ships)
            {
                shipCoordinates.AddRange(ship.ShipLocation);
            }

            return shipCoordinates;
        }
    }
}
