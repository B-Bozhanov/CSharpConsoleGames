using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class GameSettings
    {
        public int ConsoleRow;
        public int ConsoleCol;
        static int InfoWindow = 2;
        public ConsoleColor BorderColor;
        public ConsoleColor SnakeColors;
        public int SnakeLength;

        public GameSettings(int consoleRow = 30, int consoleCol = 120,  // Default values !
            ConsoleColor borderColor = ConsoleColor.DarkGray,
            ConsoleColor snakeColor = ConsoleColor.DarkBlue,
            int snakeLength = 6)
        {
            this.ConsoleRow = consoleRow;
            this.ConsoleCol = consoleCol;
            this.BorderColor = borderColor;
            this.SnakeColors = snakeColor;
            this.SnakeLength = snakeLength;

            Console.CursorVisible = false;
            Console.Title = "Snake v1.0";
            Console.WindowHeight = 1 + InfoWindow + 1 + ConsoleRow + 2;
            Console.WindowWidth = ConsoleCol;
            Console.BufferHeight = 1 + InfoWindow + 1 + ConsoleRow + 2;
            Console.BufferWidth = ConsoleCol;
            Console.OutputEncoding = Encoding.UTF8;
           // TODO: Console.LargestWindowHeight
        }
    }
}
