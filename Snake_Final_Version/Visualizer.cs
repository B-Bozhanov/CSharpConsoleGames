using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Visualizer
    {
        public  void Write(string text, int row, int col, ConsoleColor color = ConsoleColor.Black)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
