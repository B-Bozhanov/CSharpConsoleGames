﻿// Primary constructor
namespace Snake
{
    public struct Coordinates(int row, int column)
    {
        public int Row { get; set; } = row;

        public int Column { get; set; } = column;
    }
}