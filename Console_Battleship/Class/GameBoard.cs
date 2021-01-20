using System;
using System.Collections.Generic;

namespace Console_Battleship.Class
{
    public class GameBoard
    {
        public Player BoardPlayer { get; set; }
        public List<Space> Spaces { get; set; }

        public GameBoard()
        {
            this.Spaces = new List<Space>();
            this.generateSpaces();
        }

        private void generateSpaces()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    this.Spaces.Add(new Space
                    {
                        Location = new Coordinate
                        {
                            X_Axis = i,
                            Y_Axis = j
                        }
                    });
                }
            }
        }
    }
}
