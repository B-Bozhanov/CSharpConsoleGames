using System;
using System.Text;

namespace Snake
{
    internal class Field : UserKeyInput
    {
        private static int consoleRow;
        private static int consoleCol;
        private static int infoWindow;

        protected Field()
        {

        }
        public Field(Coordinates fieldSize)
        {
            infoWindow = 2;                                           // Two Rows by default
            consoleRow = 1 + infoWindow + 1 + fieldSize.Row + 1; // One is borders size.
            consoleCol = 1 + fieldSize.Col + 1;

            SetConsoleSettings();
        }
       
        protected static int ConsoleRow { get => consoleRow; }
        protected static int ConsoleCol { get => consoleCol; }
        protected static int InfoWindow { get => infoWindow; }


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
