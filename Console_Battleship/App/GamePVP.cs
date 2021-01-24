using Console_Battleship.Class;
using Console_Battleship.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_Battleship.App
{
    public static class GamePVP
    {
        public static void playGameWithPlayers(List<Player> players)
        {
            //for each player loop through
            //let them take shots
            //how to 
        }

        private static void showGameBoard(Player player)
        {
            Console.Clear();

            GlobalMethods.displayTopRow();
            for (int y = 0; y < StaticValues.Y_AXIS_SIZE; y++)
            {
                Console.Write("{0,4}", y.ToString());
                for (int x = 0; x < StaticValues.X_AXIS_SIZE; x++)
                {
                    if (player.Shots.Where(i => i.Location.X_Axis == x && i.Location.Y_Axis == y).Count() > 0)
                    {
                        if(player.Shots.Where(i => i.Location.X_Axis == x && i.Location.Y_Axis == y).FirstOrDefault().IsHit)
                        {
                            Console.Write("{0,4}", "X");
                        }
                        else
                        {
                            Console.Write("{0,4}", "O");
                        }
                    }
                    else
                    {
                        Console.Write("{0,4}", "-");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
