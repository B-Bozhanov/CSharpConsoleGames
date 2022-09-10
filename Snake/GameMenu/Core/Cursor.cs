namespace GameMenu.Core
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;

    using GameMenu.Menues;
    using GameMenu.Menues.Interfaces;

    using GameMenu.UserInputHandle;
    using GameMenu.UserInputHandle.Interfaces;

    using Snake.Utilities.Interfaces;

    internal class Cursor : ICursor<HashSet<IMenu>, ICoordinates>
    {
        private readonly IField field;
        private readonly IUserInput input;
        private readonly IWriter writer;
        private ICoordinates cursor;

        public Cursor(IWriter writer, IField field)
        {
            this.input = new UserInput();
            this.writer = writer;
            this.field = field;
        }

        public ICoordinates Move(HashSet<IMenu> menues, ICoordinates coordinates)
        {
            this.cursor = coordinates;
            while (true)
            {
                KeyPressed key = input.GetInput();

                int move = 0;
                if (key == KeyPressed.Up) move = -1;
                if (key == KeyPressed.Down) move = 1;
                if (key != KeyPressed.None) writer.Write(" ", this.cursor.Row, this.cursor.Col);
                if (key == KeyPressed.Enter) break;

                this.cursor.Row += move;

                if (this.cursor.Row < this.field.MenuRow)
                {
                    this.cursor.Row = menues.Count - 1 + this.field.MenuRow;
                }
                else if (this.cursor.Row > menues.Count - 1 + this.field.MenuRow)
                {
                    this.cursor.Row = this.field.MenuRow;
                }
                writer.Write("*", this.cursor.Row, this.cursor.Col);
            }

            return this.cursor;
        }
    }
}
