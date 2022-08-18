using SnakeProject.Models.Field.Interfaces;

namespace SnakeProject.Models.Field
{
    using SnakeProject.Utilites;
    using System.Text;

    internal abstract class GameField : IField
    {
        private const int infoWindow = 2;
        private int consoleRow;
        private int consoleCol;
        private readonly int menuRow;
        private readonly int menuCol;


        public GameField(Coordinates fieldSize)
        {
            consoleRow = 1 + infoWindow + 1 + fieldSize.Row + 1; // One is borders size.
            consoleCol = 1 + fieldSize.Col + 1;
            this.menuRow = consoleRow / 2 - 4; //TODO: Get numbers from arrays.Length(from menues)
            this.menuCol = consoleCol / 2 - 3;

            SetConsoleSettings();
        }
        public int Row
        {
            set
            {
                if (value < 0)
                {
                    // TODO:
                }
                consoleRow = value;
            }
        }

        public int Col
        {
            set
            {
                if (value < 0)
                {
                    // TODO:
                }
                consoleCol = value;
            }
        }

        public int GameInfoWindow { get => infoWindow; }
        public int MenuRow { get => this.menuRow; }
        public int MenuCol { get => this.menuCol; }

        int IField.Row => throw new NotImplementedException();

        int IField.Col => throw new NotImplementedException();

        private void SetConsoleSettings()
        {
            Console.CursorVisible = false;
            Console.Title = "Snake v2.0";
            Console.WindowHeight = consoleRow;
            Console.WindowWidth = consoleCol;
            Console.BufferHeight = consoleRow;
            Console.BufferWidth = consoleCol;
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}
