using System;
namespace Console_Battleship.Class
{
    public class Space
    {
        public Coordinate Location { get; set; }
        public bool IsHit { get; set; }
        public bool IsShot { get; set; }

        public Space()
        {
        }
    }
}
