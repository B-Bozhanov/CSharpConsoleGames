using System;
using System.Text;

namespace Snake
{
    internal class Field : UserKeyInput
    {
        protected readonly  Coordinates consoleCoords;
        protected readonly  int infoWindow;

        public Field()
        {

        }
        public Field(int row, int col)
        {
            this.consoleCoords = new Coordinates(row, col);
            this.infoWindow = infoWindow;

        }
        public Field(Coordinates fieldSize)
        {
            this.infoWindow = 2;                                      // Two Rows by default
            this.consoleCoords.Row = 1 + infoWindow + 1 + fieldSize.Row + 1; // One is borders size.
            this.consoleCoords.Col = 1 + fieldSize.Col + 1;

            SetConsoleSettings();
        }
       
        public  int ConsoleRow { get => consoleCoords.Row; }
        public  int ConsoleCol { get => consoleCoords.Col; }
        public  int InfoWindow { get => infoWindow; }

        private void SetConsoleSettings()
        {
            Console.CursorVisible = false;
            Console.Title = "Snake v1.2";
            Console.WindowHeight = consoleCoords.Row;
            Console.WindowWidth = consoleCoords.Col;
            Console.BufferHeight = consoleCoords.Row;
            Console.BufferWidth = consoleCoords.Col;
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}
