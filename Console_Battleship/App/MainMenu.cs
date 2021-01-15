using System;
namespace Console_Battleship.App
{
    public static class MainMenu
    {
        public static bool startMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to battleship!");
            Console.WriteLine();

            Console.WriteLine("Choose an option from below");
            Console.WriteLine("(1) Play against a person");
            Console.WriteLine("(2) Play against a computer");
            Console.WriteLine("(0) Exit");
            int menuChoice = takeInput("Type the number associated with your chosen option above: ");

            if(menuChoice == 1)
            {
                MenuPVP.startScreen();

                return false;
            }
            else if(menuChoice == 0)
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing! Bye now");
                return true;
            }

            return true;
        }

        private static int takeInput(string displayString)
        {
            int menuChoice = -1;
            while(menuChoice == -1)
            {
                int tempValue = 0;
                Console.Write(displayString);
                string input = Console.ReadLine();
                if(int.TryParse(input, out tempValue))
                {
                    if (isValidOption(tempValue))
                    {
                        menuChoice = tempValue;
                    }
                }
                else
                {
                    Console.WriteLine("You fucked up that ain't an option");
                }
            }
            return menuChoice;
        }

        private static bool isValidOption(int input)
        {
            if(input == 1 || input == 2 || input == 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("You fucked up that ain't an option");
                return false;
            }
        }
    }
}
