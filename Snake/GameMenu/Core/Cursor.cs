namespace GameMenu.Core
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;

    using GameMenu.Menues.Interfaces;

    using GameMenu.UserInputHandle;
    using GameMenu.UserInputHandle.Interfaces;
    using GameMenu.Utilities;

    public class Cursor : ICursor
    {
        private readonly IField field;
        private readonly IUserInput input;
        private readonly IWriter writer;

        public Cursor(IWriter writer, IField field)
        {
            this.input = new UserInput();
            this.writer = writer;
            this.field = field;
        }

        public Coordinates Move(ICollection<IMenu> menues, Coordinates cursorCoords)
        {
            while (true)
            {
                KeyPressed key = input.GetInput();

                int move = 0;
                if (key == KeyPressed.Up) move = -1;
                if (key == KeyPressed.Down) move = 1;
                if (key != KeyPressed.None) writer.Write(" ", cursorCoords.Row, cursorCoords.Col);
                if (key == KeyPressed.Enter) break;

                cursorCoords.Row += move;

                if (cursorCoords.Row < this.field.MenuRow)
                {
                    cursorCoords.Row = menues.Count - 1 + this.field.MenuRow;
                }
                else if (cursorCoords.Row > menues.Count - 1 + this.field.MenuRow)
                {
                    cursorCoords.Row = this.field.MenuRow;
                }
                writer.Write("*", cursorCoords.Row, cursorCoords.Col);
            }

            return cursorCoords;
        }
    }
}
