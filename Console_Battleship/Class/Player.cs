using System;
using System.Collections.Generic;

namespace Console_Battleship.Class
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int PlayerOrder { get; set; }

        public List<Ship> Ships { get; set; }
        public List<Shot> Spaces { get; set; }

        public Player()
        {
            this.Ships = new List<Ship>();
            this.Spaces = new List<Shot>();
        }
    }
}
