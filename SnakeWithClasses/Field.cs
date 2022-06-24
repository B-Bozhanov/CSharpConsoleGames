using System;
using System.Text;

namespace Snake
{
    internal class Field
    {
        private static int consoleRow;
        private static int consoleCol;
        private static int infoWindow;
        private static int menuRow;
        private static int menuCol;

        public Field(Coordinates fieldSize)
        {
            infoWindow = 2;
            consoleRow = 1 + infoWindow + 1 + fieldSize.Row + 1; // One is borders size.
            consoleCol = 1 + fieldSize.Col + 1;
            menuRow = consoleRow / 2 - 4; //TODO: Get numbers from arrays.Length(from menues)
            menuCol = consoleCol / 2 - 3;

            SetConsoleSettings();
        }

        public static int ConsoleRow { get => consoleRow; }
        public static int ConsoleCol { get => consoleCol; }
        public static int InfoWindow { get => infoWindow; }
        public static int MenuRow { get => menuRow; }
        public static int MenuCol { get => menuCol; }

        private void SetConsoleSettings()
        {
            Console.CursorVisible = false;
            Console.Title = "Snake v1.2";
            Console.WindowHeight = consoleRow;
            Console.WindowWidth = consoleCol;
            Console.BufferHeight = consoleRow;
            Console.BufferWidth = consoleCol;
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}
