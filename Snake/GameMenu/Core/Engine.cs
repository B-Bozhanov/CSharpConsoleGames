namespace GameMenu.Core
{
    using Interfaces;
    using GameMenu.IO;
    using GameMenu.IO.Interfaces;
    using GameMenu.Models;
    using GameMenu.Models.Interfaces;
    using Snake.Utilities;
    using Snake.Utilities.Interfaces;

    public class Engine : IEngine
    {
        private const int CursorDistance = 3;

        private HashSet<IMenu> menues;
        private readonly IWriter writer;
        private readonly IField field;
        private readonly IInterpretor interpretor;
        private readonly ICursor cursor;
        private string currentNameSpace;


        private Engine()
        {
            this.menues = new HashSet<IMenu>();
            this.writer = new ConsoleWriter();
            this.field = new ConsoleField();
            this.interpretor = new Interpretor();
            this.cursor = new Cursor(this.writer);

            NameSpaces.Push("GameMenu.Models.Menuses.MainMenu");
            this.currentNameSpace = NameSpaces.Peek();
        }
        public Engine(string test)
            : this()
        {
        }

        public void Start()
        {
            ICoordinates currentMenuCoords = new Coordinates(ConsoleField.MenuRow, ConsoleField.MenuCol);

            this.menues = this.interpretor
                .GetMenues(currentNameSpace, currentMenuCoords);

            this.writer.Write(this.menues);

            ICoordinates currentCursorCoords = new Coordinates(ConsoleField.MenuRow, currentMenuCoords.Col - CursorDistance);

            ICoordinates cursorCoordinates = this.cursor
                .Move(this.menues, currentCursorCoords);

            IMenu currentMenu = this.menues.First(m => m.MenuCoordinates.Row == cursorCoordinates.Row
                                                  && m.MenuCoordinates.Col == cursorCoordinates.Col + CursorDistance);
            this.currentNameSpace = currentMenu.Execute();
            this.writer.Clear();

            this.Start();
        }
    }
}
