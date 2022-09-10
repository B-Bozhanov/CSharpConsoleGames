﻿namespace GameMenu.Core
{
    using Interfaces;
    using GameMenu.IO;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues;
    using GameMenu.Menues.Interfaces;
    using Snake.Utilities;
    using Snake.Utilities.Interfaces;
    using GameMenu.Repository;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;
    using UserDatabase.Interfaces;
    using GameMenu.Menues.UserLoginMenu;
    using GameMenu.Menues.MainMenu;

    public class MenuEngine : IMenuEngine
    {
        private const int CursorDistance = 2;
        private readonly IRepository<string> namespaces;
        private readonly IWriter writer;
        private readonly IField field;
        private readonly IInterpretor<string, ICoordinates> interpretor;
        private readonly ICursor<HashSet<IMenu>, ICoordinates> cursor;
        private readonly IUserDatabase users;
        private readonly ICoordinates currentMenuCoords;
        private HashSet<IMenu> menues;


        private MenuEngine()
        {
            this.menues = new HashSet<IMenu>();
            this.writer = new ConsoleWriter();
            //this.field = new ConsoleField();
            this.interpretor = new Interpretor();
           
            this.namespaces = new NameSpaceRepository();

            this.namespaces.Add(NameSpacesInfo.UserLoginMenu);
        }
        public MenuEngine(IUserDatabase users, IField field)
            : this()
        {
            this.users = users;
            this.field = field;
            this.cursor = new Cursor(this.writer, this.field!);
            this.currentMenuCoords = new Coordinates(this.field.MenuRow, this.field.MenuCol);
        }

        public IUser Start()
        {
            string username = string.Empty;
            while (true)
            {
                this.currentMenuCoords.Row = this.field.MenuRow;
                this.currentMenuCoords.Col = this.field.MenuCol;

                this.menues = this.interpretor
                    .GetMenues(this.namespaces, currentMenuCoords, users);
                this.writer.Write(this.menues);

                ICoordinates currentCursorCoords = new Coordinates(this.field.MenuRow, currentMenuCoords.Col - CursorDistance);
                ICoordinates cursorCoordinates = this.cursor
                    .Move(this.menues, currentCursorCoords);

                IMenu currentMenu = this.menues.First(m => m.MenuCoordinates.Row == cursorCoordinates.Row
                                                        && m.MenuCoordinates.Col == cursorCoordinates.Col + CursorDistance);

                if (currentMenu is NewGame)
                {
                    currentMenu.Execute(this.field);
                    break;
                }
                else if (currentMenu is Login || currentMenu is CreateAccount)
                {
                    username = currentMenu.Execute(this.field);
                    this.namespaces.Add(NameSpacesInfo.MainMenu);
                }
                else
                {
                    currentMenu.Execute(this.field);
                }
                this.writer.Clear();
            }

            return this.users.Get(username);
        }
    }
}
