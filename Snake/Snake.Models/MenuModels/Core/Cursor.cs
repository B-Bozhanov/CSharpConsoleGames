namespace Snake.Models.Menu.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Snake.Common;
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.Interfaces;
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.UserInputHandle;
    using Snake.Models.Menu.UserInputHandle.Interfaces;

    public class Cursor : ICursor
    {
        private readonly IUserInput input;
        private readonly IRenderer renderer;

        public Cursor(IRenderer renderer)
        {
            input = new UserInput();
            this.renderer = renderer;
        }

        public Coordinates Move(ICollection<IMenu> menues, Coordinates cursorCoords)
        {
            var firstmenu = menues.First();

            while (true)
            {
                KeyPressed key = input.GetInput();

                int move = 0;
                if (key == KeyPressed.Up) move = -1;
                if (key == KeyPressed.Down) move = 1;
                if (key != KeyPressed.None)
                {
                    renderer.Write(" ", cursorCoords.Row, cursorCoords.Col);
                }
                if (key == KeyPressed.Enter) break;

                cursorCoords.Row += move;

                if (cursorCoords.Row < firstmenu.MenuCoordinates.Row)
                {
                    cursorCoords.Row = menues.Count - 1 + firstmenu.MenuCoordinates.Row;
                }
                else if (cursorCoords.Row > menues.Count - 1 + firstmenu.MenuCoordinates.Row)
                {
                    cursorCoords.Row = firstmenu.MenuCoordinates.Row;
                }

                renderer.Write("*", cursorCoords.Row, cursorCoords.Col);
            }

            return cursorCoords;
        }
    }
}
