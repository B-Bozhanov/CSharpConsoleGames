namespace GameMenu.Core
{
    using Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;
    using UserDatabase.Interfaces;
    using System.Reflection;

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
        private Coordinates currentMenuCoords;
        private ICollection<IMenu> menues;


        public MenuEngine(IDatabase usersDatabase, IField field, IWriter writer, IReader reader
                        , IMenuCreator menuCreator, ICursor cursor, IRepository<string> namespaces)
        {
            this.usersDatabse = usersDatabase;
            this.field = field;
            this.writer = writer;
            this.reader = reader;
            this.cursor = cursor;
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
                this.currentMenuCoords = ConsoleField.MenuStartPossition;

                this.menues = this.menuCreator.GetMenues();

                var menuesCoords = new List<Coordinates>();

                this.writer.Write(this.menues);
                foreach (var menu in this.menues)
                {
                    menuesCoords.Add(menu.MenuCoordinates);
                }

                Coordinates currentCursorCoords = new Coordinates(ConsoleField.MenuStartPossition.Row, currentMenuCoords.Col - CursorDistance);
                Coordinates cursorCoordinates = this.cursor
                    .Move(menuesCoords, currentCursorCoords);

                IMenu currentMenu = this.menues.First(m => m.MenuCoordinates.Row == cursorCoordinates.Row
                                                        && m.MenuCoordinates.Col == cursorCoordinates.Col + CursorDistance);


                var method = currentMenu.GetType()
                                        .GetMethods()
                                        .FirstOrDefault(m => m.Name == "Execute")!;
                var methodParams = method.GetParameters();

                var parameters = GetMethodParams(methodParams);
                
                string menuArgs = (string)method.Invoke(currentMenu, parameters)!;

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

        private object[] GetMethodParams(ParameterInfo[] methodParams)
        {
            var parameters =  new object[methodParams.Length];

            for (int i = 0; i < methodParams.Length; i++)
            {
                if (methodParams[i].ParameterType.Name == "IWriter")
                {
                    parameters[i] = this.writer;
                }
                if (methodParams[i].ParameterType.Name == "IReader")
                {
                    parameters[i] = this.reader;
                }
                if (methodParams[i].ParameterType.Name == "IField")
                {
                    parameters[i] = this.field;
                }
            }
            return parameters;
        }
    }
}
