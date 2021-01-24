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

            player1 = setPlayerShips(player1);
            player2 = setPlayerShips(player2);

            GlobalMethods.PauseConsoleWithStringParameter("Ready to proceed?");
            GamePVP.playGameWithPlayers(player1, player2);
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
        public static void showPlayerSetupBoard(Player player, Ship shipBeingBuilt)
        {
            List<Coordinate> playerShipCoordinates = GlobalMethods.getPlayerShipCoordinates(player);
            playerShipCoordinates.AddRange(shipBeingBuilt.ShipLocation);

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
        }
        private static Player setPlayerShips(Player player)
        {
            Console.WriteLine("Now it is time for " + player.PlayerName + " to add their ships");
            GlobalMethods.PauseConsoleWithStringParameter("Please hide the screen from the other player");

            player.Ships.Add(addShipToBoard(player, "Carrier", 5));
            player.Ships.Add(addShipToBoard(player, "Battleship", 4));
            player.Ships.Add(addShipToBoard(player, "Destroyer", 3));
            player.Ships.Add(addShipToBoard(player, "Cruiser", 3));
            player.Ships.Add(addShipToBoard(player, "Patrol Boat", 2));

            return player;
        }
        private static Ship addShipToBoard(Player player, string shipName, int shipLength)
        {
            Ship returnShip = new Ship
            {
                ShipTitle = shipName
            };
            for (int i = 0; i < shipLength; i++)
            {
                Console.Clear();
                Console.WriteLine("Place your pieces for the " + returnShip.ShipTitle + ". The number of pieces for this ship is " + shipLength.ToString());
                Console.WriteLine();
                showPlayerSetupBoard(player, returnShip);
                bool areValidCoordinates = false;
                while (!areValidCoordinates)
                {
                    int x_coordinate = GlobalMethods.takeNumericInput("Type the X coordinate for the location " + (i + 1).ToString() + " of " + shipLength.ToString() + ": ", new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                    int y_coordinate = GlobalMethods.takeNumericInput("Type the Y coordinate for the location " + (i + 1).ToString() + " of " + shipLength.ToString() + ": ", new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                    if (areShipCoordinatesValidForPlayer(player, returnShip, x_coordinate, y_coordinate))
                    {
                        areValidCoordinates = true;
                        returnShip.ShipLocation.Add(new Coordinate
                        {
                            X_Axis = x_coordinate,
                            Y_Axis = y_coordinate
                        });
                    }
                    else
                    {
                        Console.WriteLine("Those coordinates are not valid because they are either already taken or don't make a straight line. Please try again");
                    }
                }
            }

            Console.Clear();

            return returnShip;
        }
        private static bool areShipCoordinatesValidForPlayer(Player player, Ship shipBeingBuilt, int x_coordinate, int y_coordinate)
        {
            if (!isShipBeingBuiltCorrectly(shipBeingBuilt, x_coordinate, y_coordinate) || shipBeingBuilt.ShipLocation.Where(x => x.X_Axis == x_coordinate && x.Y_Axis == y_coordinate).Count() > 0)
            {
                return false;
            }
            else
            {
                foreach (Ship ship in player.Ships)
                {
                    if (ship.ShipLocation.Where(x => x.X_Axis == x_coordinate && x.Y_Axis == y_coordinate).Count() > 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        private static bool isShipBeingBuiltCorrectly(Ship shipBeingBuilt, int x_coordinate, int y_coordinate)
        {
            if (shipBeingBuilt.ShipLocation.Count == 0)
            {
                return true;
            }
            else if (shipBeingBuilt.ShipLocation.Count == 1)
            {
                //must be in 4 locations around it
                int existing_x_coordinate = shipBeingBuilt.ShipLocation.FirstOrDefault().X_Axis;
                int existing_y_coordinate = shipBeingBuilt.ShipLocation.FirstOrDefault().Y_Axis;

                List<Coordinate> allowableCoordinates = new List<Coordinate>
                {
                    new Coordinate
                    {
                        X_Axis = existing_x_coordinate - 1,
                        Y_Axis = existing_y_coordinate
                    },
                    new Coordinate
                    {
                        X_Axis = existing_x_coordinate + 1,
                        Y_Axis = existing_y_coordinate
                    },
                    new Coordinate
                    {
                        X_Axis = existing_x_coordinate,
                        Y_Axis = existing_y_coordinate - 1
                    },
                    new Coordinate
                    {
                        X_Axis = existing_x_coordinate,
                        Y_Axis = existing_y_coordinate + 1
                    }
                };

                if(allowableCoordinates.Where(i => i.X_Axis == x_coordinate && i.Y_Axis == y_coordinate).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //take the values that establish a line and only allow spots at the beginning or end
                if(shipBeingBuilt.ShipLocation[0].X_Axis == shipBeingBuilt.ShipLocation[1].X_Axis)
                {
                    //must make line on x axis
                    int maximum_y_coordinate = shipBeingBuilt.ShipLocation.OrderByDescending(i => i.Y_Axis).FirstOrDefault().Y_Axis + 1;
                    int minimum_y_coordinate = shipBeingBuilt.ShipLocation.OrderByDescending(i => i.Y_Axis).LastOrDefault().Y_Axis -1;
                    if(x_coordinate == shipBeingBuilt.ShipLocation[0].X_Axis && (y_coordinate == maximum_y_coordinate || y_coordinate == minimum_y_coordinate))
                    {
                        return true;
                    }
                }
                else
                {
                    //it's the y axis
                    //must make line on x axis
                    int maximum_x_coordinate = shipBeingBuilt.ShipLocation.OrderByDescending(i => i.X_Axis).FirstOrDefault().X_Axis + 1;
                    int minimum_x_coordinate = shipBeingBuilt.ShipLocation.OrderByDescending(i => i.X_Axis).LastOrDefault().X_Axis - 1;
                    if (y_coordinate == shipBeingBuilt.ShipLocation[0].Y_Axis && (x_coordinate == maximum_x_coordinate || x_coordinate == minimum_x_coordinate))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}