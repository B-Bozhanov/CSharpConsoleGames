using Snake.UserInput;

namespace Snake.Menu
{
    internal class Cursor : GameMenu
    {
        private readonly char symbol;

        internal Cursor(int consoleRow, int consolecOL)
        {
            this.Position = new Coordinates(consoleRow, consolecOL);
            this.Position.Col -= 2;   // decreese cols by two possitions, to visualized left on menu;
            this.symbol = '*';
        }

        internal Coordinates Position { get; private set; }

        internal void Move(int menuLength, int consoleRow)
        {
            while (true)
            {
                int move = 0;
                var key = GetInput();

                if (key == KeyPressed.Up) move = -1;
                if (key == KeyPressed.Down) move = 1;
                if (key != KeyPressed.None) Visualizer.DrowingCursor(' ', this.Position);
                if (key == KeyPressed.Enter) break;

                this.Position.Row += move;

                if (this.Position.Row < consoleRow)
                {
                    this.Position.Row = consoleRow;
                }
                else if (this.Position.Row > consoleRow + menuLength - 1)
                {
                    this.Position.Row = consoleRow + menuLength - 1;
                }
                Visualizer.DrowingCursor(this.symbol, this.Position);
            }
            this.Position.Col += 2; //restore origin col position
        }
    }
}
