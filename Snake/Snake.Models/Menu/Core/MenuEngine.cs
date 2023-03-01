namespace Snake.Models.Menu.Core
{
    using System.Reflection;

    using Interfaces;

    using Snake.Common;
    using Snake.Models.Menu.Interfaces;
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    using UserDatabase.Interfaces;

    public class MenuEngine : IMenuEngine
    {
        private const int CursorDistance = 2;

        private readonly IRepository<string> namespaces;
        private readonly IRenderer renderer;
        private readonly IField field;
        private readonly IMenuCreator menuCreator;
        private readonly ICursor cursor;
        private readonly IDatabase usersDatabse;
        private Coordinates currentMenuCoords;
        private ICollection<IMenu> menues;
        private Border border;


        public MenuEngine(IDatabase usersDatabase, IField field, IRenderer renderer
                        , IMenuCreator menuCreator, ICursor cursor, IRepository<string> namespaces)
        {
            usersDatabse = usersDatabase;
            this.field = field;
            this.renderer = renderer;
            this.cursor = cursor;
            menues = new HashSet<IMenu>();
            this.namespaces = namespaces;
            this.namespaces.Add(NameSpacesInfo.UserLoginMenu);
            this.menuCreator = menuCreator;
            border = new Border(this.field);
        }

        public IAccount Start()
        {
            renderer.Write(border.InfoWindow());
            renderer.Write(border.Walls());
            string username = string.Empty;
            string password = string.Empty;
            bool isGuestPlayer = false;

            while (true)
            {
                currentMenuCoords = ConsoleField.MenuStartPossition;
                menues = menuCreator.GetMenues();
                renderer.Write(menues);

                Coordinates currentCursorCoords = new Coordinates(ConsoleField.MenuStartPossition.Row, currentMenuCoords.Col - CursorDistance);
                Coordinates cursorCoordinates = cursor.Move(menues, currentCursorCoords);

                IMenu currentMenu = menues.First(m => m.MenuCoordinates.Row == cursorCoordinates.Row
                                                        && m.MenuCoordinates.Col == cursorCoordinates.Col + CursorDistance);


                var method = currentMenu.GetType()
                                        .GetMethods()
                                        .FirstOrDefault(m => m.Name == "Execute")!;

                var methodParams = method.GetParameters();
                var parameters = GetMethodParams(methodParams);

                var menuArgs = (string)method.Invoke(currentMenu, parameters)!;

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
                renderer.Clear();
            }

            if (isGuestPlayer)
            {
                return usersDatabse.GetAccount("Guest", null!);
            }

            return usersDatabse.GetAccount(username, password);
        }

        private object[] GetMethodParams(ParameterInfo[] methodParams)
        {
            var parameters = new object[methodParams.Length];

            for (int i = 0; i < methodParams.Length; i++)
            {
                if (methodParams[i].ParameterType.Name == "IRenderer")
                {
                    parameters[i] = renderer;
                }
                if (methodParams[i].ParameterType.Name == "IField")
                {
                    parameters[i] = field;
                }
            }
            return parameters;
        }
    }
}
