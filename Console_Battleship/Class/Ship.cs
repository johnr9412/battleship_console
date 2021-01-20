using System;
using System.Collections.Generic;

namespace Console_Battleship.Class
{
    public class Ship
    {
        public string ShipTitle { get; set; }
        public List<Coordinate> ShipLocation { get; set; }
        public Ship()
        {
            this.ShipLocation = new List<Coordinate>();
        }
    }
}
