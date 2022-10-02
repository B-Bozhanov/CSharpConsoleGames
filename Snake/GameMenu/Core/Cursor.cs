namespace GameMenu.Core
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;

    using GameMenu.UserInputHandle;
    using GameMenu.UserInputHandle.Interfaces;
    using GameMenu.Utilities;

    public class Cursor : ICursor
    {
        private readonly IUserInput input;
        private readonly IWriter writer;

        public Cursor(IWriter writer)
        {
            this.input = new UserInput();
            this.writer = writer;
        }

        public Coordinates Move(ICollection<Coordinates> coords, Coordinates cursorCoords)
        {
            var firstCoord = coords.First();

            while (true)
            {
                KeyPressed key = input.GetInput();

                int move = 0;
                if (key == KeyPressed.Up) move = -1;
                if (key == KeyPressed.Down) move = 1;
                if (key != KeyPressed.None)
                {
                   writer.Write(" ", cursorCoords.Row, cursorCoords.Col);
                }
                if (key == KeyPressed.Enter) break;

                cursorCoords.Row += move;

                if (cursorCoords.Row < firstCoord.Row)
                {
                    cursorCoords.Row = coords.Count - 1 + firstCoord.Row;
                }
                else if (cursorCoords.Row > coords.Count - 1 + firstCoord.Row)
                {
                    cursorCoords.Row = firstCoord.Row;
                }

                writer.Write("*", cursorCoords.Row, cursorCoords.Col);
            }

            return cursorCoords;
        }
    }
}
