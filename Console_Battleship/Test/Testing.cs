using Console_Battleship.App;
using Console_Battleship.Class;
using Console_Battleship.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Battleship.Test
{
    public static class Testing
    {
        public static void automateSetup()
        {
            List<Player> players = new List<Player>
            {
                new Player
                {
                    PlayerName = "John",
                    PlayerOrder = 1,
                    Ships = new List<Ship>
                    {
                        new Ship
                        {
                            ShipLocation = new List<Coordinate>
                            {
                                new Coordinate
                                {
                                    X_Axis =1,
                                    Y_Axis = 1
                                },
                                new Coordinate
                                {
                                    X_Axis =1,
                                    Y_Axis = 2
                                },
                                new Coordinate
                                {
                                    X_Axis =1,
                                    Y_Axis = 3
                                },
                                new Coordinate
                                {
                                    X_Axis =1,
                                    Y_Axis = 4
                                },
                                new Coordinate
                                {
                                    X_Axis =1,
                                    Y_Axis = 5
                                }
                            },
                            ShipTitle = "Carrier"
                        },
                        new Ship
                        {
                            ShipLocation = new List<Coordinate>
                            {
                                new Coordinate
                                {
                                    X_Axis =1,
                                    Y_Axis = 8
                                },
                                new Coordinate
                                {
                                    X_Axis =2,
                                    Y_Axis = 8
                                },
                                new Coordinate
                                {
                                    X_Axis =3,
                                    Y_Axis = 8
                                },
                                new Coordinate
                                {
                                    X_Axis =4,
                                    Y_Axis = 8
                                }
                            },
                            ShipTitle = "Battleship"
                        },
                        new Ship
                        {
                            ShipLocation = new List<Coordinate>
                            {
                                new Coordinate
                                {
                                    X_Axis =6,
                                    Y_Axis = 0
                                },
                                new Coordinate
                                {
                                    X_Axis =7,
                                    Y_Axis = 0
                                },
                                new Coordinate
                                {
                                    X_Axis =8,
                                    Y_Axis = 0
                                }
                            },
                            ShipTitle = "Destroyer"
                        },
                        new Ship
                        {
                            ShipLocation = new List<Coordinate>
                            {
                                new Coordinate
                                {
                                    X_Axis =8,
                                    Y_Axis = 6
                                },
                                new Coordinate
                                {
                                    X_Axis =8,
                                    Y_Axis = 7
                                },
                                new Coordinate
                                {
                                    X_Axis =8,
                                    Y_Axis = 8
                                }
                            },
                            ShipTitle = "Cruiser"
                        },
                        new Ship
                        {
                            ShipLocation = new List<Coordinate>
                            {
                                new Coordinate
                                {
                                    X_Axis =5,
                                    Y_Axis = 3
                                },
                                new Coordinate
                                {
                                    X_Axis =5,
                                    Y_Axis = 4
                                }
                            },
                            ShipTitle = "Patrol Boat"
                        }
                    }
                },
                new Player
                {
                    PlayerName = "Mimi",
                    PlayerOrder = 2,
                    Ships = new List<Ship>
                    {
                        new Ship
                        {
                            ShipLocation = new List<Coordinate>
                            {
                                new Coordinate
                                {
                                    X_Axis =9,
                                    Y_Axis = 5
                                },
                                new Coordinate
                                {
                                    X_Axis =9,
                                    Y_Axis = 6
                                },
                                new Coordinate
                                {
                                    X_Axis =9,
                                    Y_Axis = 7
                                },
                                new Coordinate
                                {
                                    X_Axis =9,
                                    Y_Axis = 8
                                },
                                new Coordinate
                                {
                                    X_Axis =9,
                                    Y_Axis = 9
                                }
                            },
                            ShipTitle = "Carrier"
                        },
                        new Ship
                        {
                            ShipLocation = new List<Coordinate>
                            {
                                new Coordinate
                                {
                                    X_Axis =1,
                                    Y_Axis = 8
                                },
                                new Coordinate
                                {
                                    X_Axis =2,
                                    Y_Axis = 8
                                },
                                new Coordinate
                                {
                                    X_Axis =3,
                                    Y_Axis = 8
                                },
                                new Coordinate
                                {
                                    X_Axis =4,
                                    Y_Axis = 8
                                }
                            },
                            ShipTitle = "Battleship"
                        },
                        new Ship
                        {
                            ShipLocation = new List<Coordinate>
                            {
                                new Coordinate
                                {
                                    X_Axis =0,
                                    Y_Axis = 0
                                },
                                new Coordinate
                                {
                                    X_Axis =1,
                                    Y_Axis = 0
                                },
                                new Coordinate
                                {
                                    X_Axis =2,
                                    Y_Axis = 0
                                }
                            },
                            ShipTitle = "Destroyer"
                        },
                        new Ship
                        {
                            ShipLocation = new List<Coordinate>
                            {
                                new Coordinate
                                {
                                    X_Axis =7,
                                    Y_Axis = 6
                                },
                                new Coordinate
                                {
                                    X_Axis =7,
                                    Y_Axis = 7
                                },
                                new Coordinate
                                {
                                    X_Axis =7,
                                    Y_Axis = 8
                                }
                            },
                            ShipTitle = "Cruiser"
                        },
                        new Ship
                        {
                            ShipLocation = new List<Coordinate>
                            {
                                new Coordinate
                                {
                                    X_Axis =4,
                                    Y_Axis = 1
                                },
                                new Coordinate
                                {
                                    X_Axis =4,
                                    Y_Axis = 2
                                }
                            },
                            ShipTitle = "Patrol Boat"
                        }
                    }
                }
            };
            GamePVP.playGameWithPlayers(players[0], players[1]);
            GlobalMethods.PauseConsoleWithoutStringParameter();
        }
    }
}
