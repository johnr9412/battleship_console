using System;
using System.Collections.Generic;
using Console_Battleship.Global;
using Console_Battleship.Test;

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
            int menuChoice = GlobalMethods.takeNumericInput("Type the number associated with your chosen option above: ", StaticValues.ALLOWABLE_MAIN_MENU_CHOICES);

            if(menuChoice == 1)
            {
                MenuPVP.setupPVP();

                return false;
            }
            else if(menuChoice == 0)
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing! Bye now");
                return true;
            }
            else if(menuChoice == 69)
            {
                Console.Clear();
                Testing.automateSetup();
                return false;
            }

            return true;
        }
    }
}
