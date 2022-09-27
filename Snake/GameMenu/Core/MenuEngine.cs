namespace GameMenu.Core
{
    using Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using Snake.Utilities;
    using Snake.Utilities.Interfaces;
    using GameMenu.Repository;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;
    using UserDatabase.Interfaces;
    using GameMenu.Menues.UserLoginMenu;
    using GameMenu.Menues.MainMenu;
    using UserDatabase;

    public class MenuEngine : IMenuEngine
    {
        private const int CursorDistance = 2;
        private readonly IRepository<string> namespaces;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IField field;
        private readonly IInterpretor<string, ICoordinates> interpretor;
        private readonly ICursor<HashSet<IMenu>, ICoordinates> cursor;
        private readonly IDatabase users;
        private readonly ICoordinates currentMenuCoords;
        private HashSet<IMenu> menues;


        public MenuEngine(IDatabase users, IField field, IWriter writer, IReader reader)
        {
            this.users = users;
            this.field = field;
            this.writer = writer;
            this.reader = reader;
            this.cursor = new Cursor(this.writer, this.field!);
            this.currentMenuCoords = new Coordinates(this.field.MenuRow, this.field.MenuCol);
            this.menues = new HashSet<IMenu>();
            this.interpretor = new Interpretor();
            this.namespaces = new NameSpaceRepository();
            this.namespaces.Add(NameSpacesInfo.UserLoginMenu);
        }

        public IAccount Start()
        {
            string username = string.Empty;
            string password = string.Empty;
            bool isGuestPlayer = false;

            while (true)
            {
                this.currentMenuCoords.Row = this.field.MenuRow;
                this.currentMenuCoords.Col = this.field.MenuCol;

                this.menues = this.interpretor
                    .GetMenues(this.namespaces, this.currentMenuCoords, this.users);

                foreach (var menu in this.menues)
                {
                    this.writer.Write(menu.GetName(), menu.MenuCoordinates.Row, menu.MenuCoordinates.Col);
                }

                ICoordinates currentCursorCoords = new Coordinates(this.field.MenuRow, currentMenuCoords.Col - CursorDistance);
                ICoordinates cursorCoordinates = this.cursor
                    .Move(this.menues, currentCursorCoords);

                IMenu currentMenu = this.menues.First(m => m.MenuCoordinates.Row == cursorCoordinates.Row
                                                        && m.MenuCoordinates.Col == cursorCoordinates.Col + CursorDistance);
                string menuArgs = currentMenu.Execute(this.field, this.writer, this.reader);

                if (menuArgs == "NewGame")
                {
                    break;
                }
                else if (menuArgs == "ContinueWithoutAccount")
                {
                    isGuestPlayer = true;
                }
                else
                {
                    var accountArgs = menuArgs.Split(Environment.NewLine);
                    username = accountArgs[0];
                    password = accountArgs[1];
                }
                this.writer.Clear();
            }

            if (isGuestPlayer)
            {
                return this.users.GetAccount("Guest", null);
            }
            return this.users.GetAccount(username, password);
        }
    }
}
