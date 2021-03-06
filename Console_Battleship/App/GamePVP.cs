﻿using Console_Battleship.Class;
using Console_Battleship.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_Battleship.App
{
    public static class GamePVP
    {
        public static void playGameWithPlayers(Player player1, Player player2)
        {
            bool victoryCondition = false;
            while (!victoryCondition)
            {
                player1 = currentPlayerTurnVsOpponent(player1, player2);
                if (didPlayerSinkAllOpponentShips(player1, player2.Ships))
                {
                    Console.Clear();
                    Console.WriteLine("YOU WIN!!! ");
                    GlobalMethods.PauseConsoleWithStringParameter("WAY TO GO " + player1.PlayerName);
                    victoryCondition = true;
                    break;
                }
                else
                {
                    GlobalMethods.PauseConsoleWithStringParameter("Get ready to give the screen to the next player");
                }


                player2 = currentPlayerTurnVsOpponent(player2, player1);
                if (didPlayerSinkAllOpponentShips(player2, player1.Ships))
                {
                    Console.Clear();
                    Console.WriteLine("YOU WIN!!! ");
                    GlobalMethods.PauseConsoleWithStringParameter("WAY TO GO " + player2.PlayerName);
                    victoryCondition = true;
                    break;
                }
                else
                {
                    GlobalMethods.PauseConsoleWithStringParameter("Get ready to give the screen to the next player");
                }
            }
        }
        private static void showGameBoardForPlayer(Player player)
        {
            GlobalMethods.displayTopRow();
            for (int y = 0; y < StaticValues.Y_AXIS_SIZE; y++)
            {
                Console.Write("{0,4}", y.ToString());
                for (int x = 0; x < StaticValues.X_AXIS_SIZE; x++)
                {
                    if (player.Shots.Where(i => i.Location.X_Axis == x && i.Location.Y_Axis == y).Count() > 0)
                    {
                        if (player.Shots.Where(i => i.Location.X_Axis == x && i.Location.Y_Axis == y).FirstOrDefault().IsHit)
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
        private static Player currentPlayerTurnVsOpponent(Player currentPlayer, Player opponentPlayer)
        {
            Shot currentPlayerShot = getShotCoordinatesForPlayerVsPlayer(currentPlayer, opponentPlayer);
            if (evaluateShotAsHit(currentPlayerShot))
            {
                if (doesShotSinkTheOpponentsShip(currentPlayerShot, currentPlayer.Shots.Where(shot => shot.IsHit == true).Select(shot => new Coordinate { X_Axis = shot.Location.X_Axis, Y_Axis = shot.Location.Y_Axis }).ToList(), opponentPlayer.Ships))
                {
                    Console.WriteLine("You sunk their ship!");
                }
            }

            Console.WriteLine();
            currentPlayer.Shots.Add(currentPlayerShot);
            showGameBoardForPlayer(currentPlayer);

            return currentPlayer;
        }
        private static Shot getShotCoordinatesForPlayerVsPlayer(Player playerShooting, Player playerBeingShot)
        {
            Shot returnShot = new Shot();

            Console.Clear();
            Console.WriteLine(playerShooting.PlayerName + " shooting " + playerBeingShot.PlayerName);
            showGameBoardForPlayer(playerShooting);
            bool areValidCoordinates = false;
            while (!areValidCoordinates)
            {
                int x_coordinate = GlobalMethods.takeNumericInput("Type the X coordinate for your shot: ", new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                int y_coordinate = GlobalMethods.takeNumericInput("Type the Y coordinate for your shot: ", new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                if (!areShotCoordinatesAlreadyTakeByPlayer(playerShooting, x_coordinate, y_coordinate))
                {
                    returnShot.Location = new Coordinate
                    {
                        X_Axis = x_coordinate,
                        Y_Axis = y_coordinate
                    };
                    returnShot.IsHit = doesShotHitTheOpponentsShips(x_coordinate, y_coordinate, playerBeingShot);

                    areValidCoordinates = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You already shot there. Please try again");
                }
            }

            return returnShot;
        }
        private static bool areShotCoordinatesAlreadyTakeByPlayer(Player playerShooting, int x_coordinate, int y_coordinate)
        {
            if(playerShooting.Shots.Where(shot => shot.Location.X_Axis == x_coordinate && shot.Location.Y_Axis == y_coordinate).Count() > 0)
            {
                return true;
            }
            return false;
        }
        private static bool doesShotHitTheOpponentsShips(int x_coordinate, int y_coordinate, Player playerBeingShot)
        {
            foreach(Ship playerShip in playerBeingShot.Ships)
            {
                if(playerShip.ShipLocation.Where(location => location.X_Axis == x_coordinate && location.Y_Axis == y_coordinate).Count() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool evaluateShotAsHit(Shot shot)
        {
            Console.Clear();
            if (shot.IsHit)
            {
                Console.WriteLine("That's a HIT!!!");
                return true;
            }
            else
            {
                Console.WriteLine("MISS!!!");
                return false;
            }
        }
        private static bool doesShotSinkTheOpponentsShip(Shot shot, List<Coordinate> shots, List<Ship> opponentShips)
        {
            int test = 0;
            foreach(Ship ship in opponentShips)
            {
                if(ship.ShipLocation.Where(ship => ship.X_Axis == shot.Location.X_Axis && ship.Y_Axis == shot.Location.Y_Axis).Count() > 0)
                {
                    shots.Add(shot.Location);
                    int tally = 0;
                    foreach(Coordinate coordinate in ship.ShipLocation)
                    {
                        if(shots.Where(temp => temp.X_Axis == coordinate.X_Axis && temp.Y_Axis == coordinate.Y_Axis).Count() > 0)
                        {
                            tally++;
                        }
                    }

                    if(tally == ship.ShipLocation.Count)
                    {
                        test = 1;
                        return true;
                    }
                }
            }

            return false;
        }
        private static bool didPlayerSinkAllOpponentShips(Player currentPlayer, List<Ship> opponentShips)
        {
            //Get all current player's shots into a list of coordinates
            List<Coordinate> currentPlayerShots = currentPlayer.Shots.Where(x => x.IsHit == true).Select(shot => new Coordinate { X_Axis = shot.Location.X_Axis, Y_Axis = shot.Location.Y_Axis }).ToList();

            //Get all opponent player's ships into a list of coordinates
            List<Coordinate> shipCoordinates = new List<Coordinate>();
            foreach(Ship ship in opponentShips)
            {
                shipCoordinates.AddRange(ship.ShipLocation);
            }

            //Check each ship coordinate if it exists in the current player's list of shots
            //If any ship coordinates are found that aren't in the list of shots, return a false
            foreach (Coordinate coordinate in shipCoordinates)
            {
                if(currentPlayerShots.Where(x => x.X_Axis == coordinate.X_Axis && x.Y_Axis == coordinate.Y_Axis).Count() == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
