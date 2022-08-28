﻿namespace GameMenu.Core
{
    using Interfaces;
    using GameMenu.IO;
    using GameMenu.IO.Interfaces;
    using GameMenu.Models;
    using GameMenu.Models.Interfaces;
    using Snake.Utilities;
    using Snake.Utilities.Interfaces;
    using GameMenu.Repository;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;
    using GameMenu.Models.WellcomeScreen;
    using UsersDatabse.Interfaces;

    public class MenuEngine : IMenuEngine
    {
        private const int CursorDistance = 2;
        private readonly IUserDatabase userDatabase;
        private readonly IRepository<string> namespaces;
        private readonly IWriter writer;
        private readonly IField field;
        private readonly IInterpretor<string, ICoordinates> interpretor;
        private readonly ICursor cursor;
        private readonly ICoordinates currentMenuCoords;
        private HashSet<IMenu> menues;


        private MenuEngine()
        {
            this.menues = new HashSet<IMenu>();
            this.writer = new ConsoleWriter();
            this.field = new ConsoleField();
            this.interpretor = new Interpretor();
            this.cursor = new Cursor(this.writer);
            this.currentMenuCoords = new Coordinates(ConsoleField.MenuRow, ConsoleField.MenuCol);

            var wellcomeScreen = new WellcomeScreen(currentMenuCoords.Row, currentMenuCoords.Col, this.writer);
            this.namespaces = new NameSpaceRepository();

            this.namespaces.Push(NameSpacesInfo.UserLoginMenu);
        }
        public MenuEngine(IUserDatabase userDatabase)
            : this()
        {
            this.userDatabase = userDatabase;
        }

        public IUser Start()
        {
            this.currentMenuCoords.Row = ConsoleField.MenuRow;
            this.currentMenuCoords.Col = ConsoleField.MenuCol;

            this.menues = this.interpretor
                .GetMenues(this.namespaces, currentMenuCoords);
            this.writer.Write(this.menues);

            ICoordinates currentCursorCoords = new Coordinates(ConsoleField.MenuRow, currentMenuCoords.Col - CursorDistance);
            ICoordinates cursorCoordinates = this.cursor
                .Move(this.menues, currentCursorCoords);

            IMenu currentMenu = this.menues.First(m => m.MenuCoordinates.Row == cursorCoordinates.Row
                                                  && m.MenuCoordinates.Col == cursorCoordinates.Col + CursorDistance);

            if (currentMenu.Execute() == "NewGame")
            {
                return null;
            }
            return null;
            this.writer.Clear();

            this.Start();
        }
    }
}