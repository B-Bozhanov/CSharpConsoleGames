﻿namespace GameMenu.Utilities
{
    public class Coordinates 
    {
        public Coordinates()
        {
            
        }
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}
