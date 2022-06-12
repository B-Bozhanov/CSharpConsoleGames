using Snake.UserInput;

namespace Snake.Menu
{
    internal class Cursor : UserKeyInput
    {
        public Cursor(int row, int col)
        {
            this.Position = new Coordinates(row, col);
            Position.Col -= 2;   // decreese cols by two possitions, to visualized left on menu;
            this.Symbol = '*';
        }

        public Coordinates Position { get; private set; }
        public char Symbol { get; private set; }

        public void Move(int menuLength, int consoleRow)
        {
            while (true)
            {
                int move = 0;
                var key = GetInput();

                if (key == KeyPressed.Up) move = -1;
                if (key == KeyPressed.Down) move = 1;
                if (key != KeyPressed.None) Visualizer.DrowingCursor(' ', Position);
                if (key == KeyPressed.Enter) break;

                Position.Row += move;

                if (this.Position.Row < consoleRow)
                {
                    this.Position.Row = consoleRow;
                }
                else if (this.Position.Row > consoleRow + menuLength - 1)
                {
                    this.Position.Row = consoleRow + menuLength - 1;
                }
                Visualizer.DrowingCursor(Symbol, Position);
            }
            Position.Col += 2; //restore origin col position
        }
    }
}
