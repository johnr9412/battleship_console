using System;
using System.Collections.Generic;

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
    }
}
