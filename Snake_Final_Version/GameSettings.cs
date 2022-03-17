using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class GameSettings
    {
        public  int ConsoleRow = 30;
        public  int ConsoleCol = 120;
        static int InfoWindow;
        public ConsoleColor BorderColor;
        public ConsoleColor SnakeColors;
        public int SnakeLength;

        public GameSettings()
        {
            //this.ConsoleRow = consoleRow;
            //this.ConsoleCol = consoleCol;
            //this.BorderColor = borderColor;
            //this.SnakeColors = snakeColor;
            //this.SnakeLength = snakeLength;
        }
        public void ConsoleSettings()
        {
            //this.ConsoleRow = consoleRow;
            //this.ConsoleCol = consoleCol;
            Console.CursorVisible = false;
            Console.Title = "Snake v1.0";
            Console.WindowHeight = 1 + InfoWindow + 1 + ConsoleRow + 2;
            Console.WindowWidth = ConsoleCol;
            Console.BufferHeight = 1 + InfoWindow + 1 + ConsoleRow + 2;
            Console.BufferWidth = ConsoleCol;
            Console.OutputEncoding = Encoding.UTF8;
            //int maxHeight = Console.LargestWindowHeight;
            //int maxWidth = Console.LargestWindowWidth;
        }
    }
}
