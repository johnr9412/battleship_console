using System;
namespace Console_Battleship.Class
{
    public class Shot
    {
        public Coordinate Location { get; set; }
        public bool IsHit { get; set; }

        public Shot()
        {
        }
    }
}
