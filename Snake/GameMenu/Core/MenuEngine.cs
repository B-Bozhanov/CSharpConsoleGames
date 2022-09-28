namespace GameMenu.Core
{
    using Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;
    using UserDatabase.Interfaces;

    public class MenuEngine : IMenuEngine
    {
        private const int CursorDistance = 2;

        private readonly IRepository<string> namespaces;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IField field;
        private readonly IMenuCreator menuCreator;
        private readonly ICursor cursor;
        private readonly IDatabase usersDatabse;
        private readonly Coordinates currentMenuCoords;
        private ICollection<IMenu> menues;


        public MenuEngine(IDatabase usersDatabase, IField field, IWriter writer, IReader reader
                        , IMenuCreator menuCreator, ICursor cursor, IRepository<string> namespaces)
        {
            this.usersDatabse = usersDatabase;
            this.field = field;
            this.writer = writer;
            this.reader = reader;
            this.cursor = cursor;
            this.currentMenuCoords = new Coordinates(this.field.MenuRow, this.field.MenuCol);
            this.menues = new HashSet<IMenu>();
            this.namespaces = namespaces;
            this.namespaces.Add(NameSpacesInfo.UserLoginMenu);
            this.menuCreator = menuCreator;
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

                this.menues = this.menuCreator
                    .GetMenues(this.currentMenuCoords);

                foreach (var menu in this.menues)
                {
                    this.writer.Write(menu.GetName(), menu.MenuCoordinates.Row, menu.MenuCoordinates.Col);
                }

                Coordinates currentCursorCoords = new Coordinates(this.field.MenuRow, currentMenuCoords.Col - CursorDistance);
                Coordinates cursorCoordinates = this.cursor
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
                else if (menuArgs != null)
                {
                    var accountArgs = menuArgs.Split(Environment.NewLine);
                    username = accountArgs[0];
                    password = accountArgs[1];
                }
                this.writer.Clear();
            }

            if (isGuestPlayer)
            {
                return this.usersDatabse.GetAccount("Guest", null!);
            }

            return this.usersDatabse.GetAccount(username, password);
        }
    }
}
