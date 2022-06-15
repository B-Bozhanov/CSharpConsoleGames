using System;
using System.Text;

namespace Snake
{
    internal class Field : UserKeyInput
    {
        protected readonly  int consoleRow;
        protected readonly  int consoleCol;
        protected readonly  int infoWindow;

        public Field()
        {

        }
        public Field(int row, int col)
        {
            this.consoleRow = row;
            this.consoleCol = col;
            this.infoWindow = infoWindow;

        }
        public Field(Coordinates fieldSize)
        {
            this.infoWindow = 2;                                      // Two Rows by default
            this.consoleRow = 1 + infoWindow + 1 + fieldSize.Row + 1; // One is borders size.
            this.consoleCol = 1 + fieldSize.Col + 1;

            SetConsoleSettings();
        }
       
        public  int ConsoleRow { get => consoleRow; }
        public  int ConsoleCol { get => consoleCol; }
        public  int InfoWindow { get => infoWindow; }

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
