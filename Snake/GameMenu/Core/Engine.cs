namespace GameMenu.Core
{
    using Interfaces;
    using GameMenu.IO;
    using GameMenu.IO.Interfaces;
    using GameMenu.Models;
    using GameMenu.Models.Interfaces;
    using Snake.Utilities;
    using Snake.Utilities.Interfaces;
    using GameMenu.Models.Menuses.MainMenu.Interfaces;

    public class Engine : IEngine
    {
        private const int CursorDistance = 3;

        private HashSet<IMenu> menues;
        private readonly IWriter writer;
        private readonly IField field;
        private readonly IInterpretor interpretor;
        private readonly ICursor cursor;
        private Type currentType;

        private Engine()
        {
            this.menues = new HashSet<IMenu>();
            this.writer = new ConsoleWriter();
            this.field = new ConsoleField();
            this.interpretor = new Interpretor();
            this.cursor = new Cursor(this.writer);

            InterfaceRepository<Type>.Push(typeof(IMainMenu));
            this.currentType = InterfaceRepository<Type>.Peek();

            this.currentType = typeof(IMainMenu);
        }
        public Engine(string test)
            : this()
        {
        }

        public void Start()
        {
            ICoordinates currentMenuCoords = new Coordinates(ConsoleField.MenuRow, ConsoleField.MenuCol);

            this.menues = this.interpretor
                .GetMenues(currentType, currentMenuCoords);

            this.writer.Write(this.menues);

            ICoordinates currentCursorCoords = new Coordinates(currentMenuCoords.Row, currentMenuCoords.Col - CursorDistance);

            ICoordinates cursorCoordinates = this.cursor
                .Move(this.menues, currentCursorCoords);

            IMenu currentMenu = this.menues.First(m => m.MenuCoordinates.Row == cursorCoordinates.Row
                                                  && m.MenuCoordinates.Col == cursorCoordinates.Col + CursorDistance);

            this.currentType = currentMenu.Execute();
            this.writer.Clear();
            this.Start();
        }
    }
}
