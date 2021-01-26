using System;
using Console_Battleship.App;
using Console_Battleship.Global;

namespace Console_Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!MainMenu.startMenu()) ;

            GlobalMethods.PauseConsoleWithoutStringParameter();
        }
    }
}