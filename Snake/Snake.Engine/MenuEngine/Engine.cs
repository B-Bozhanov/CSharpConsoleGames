namespace Snake.Engine.MenuEngine
{
    using System;
    using System.Reflection;

    using Snake.Common;
    using Snake.Engine.MenuEngine.Interfaces;
    using Snake.Models.Menu;
    using Snake.Models.Menu.Core;
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.Interfaces;
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;
    using Snake.Models.MenuModels.Core.Interfaces;
    using Snake.Services;

    using UserDatabase.Interfaces;

    public class Engine : IMenuEngine
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
        private IBorderService boardService;


        public Engine(IDatabase usersDatabase, IField field, IRenderer renderer
                        ,IMenuCreator menuCreator, ICursor cursor, IRepository<string> namespaces
                        ,IBorderService boardService)
        {
            this.usersDatabse = usersDatabase;
            this.field = field;
            this.renderer = renderer;
            this.cursor = cursor;
            this.menues = new HashSet<IMenu>();
            this.namespaces = namespaces;
            this.namespaces.Add(NameSpacesInfo.UserLoginMenu);
            this.menuCreator = menuCreator;
            this.boardService = boardService;
        }

        public IAccount Start()
        {
            this.renderer.Write(this.boardService.GetInfoWindow());
            this.renderer.Write(this.boardService.GetWalls());
            string username = string.Empty;
            string password = string.Empty;
            bool isGuestPlayer = false;

            while (true)
            {
                this.renderer.Write(this.boardService.GetInfoWindow());
                this.renderer.Write(this.boardService.GetWalls());
                currentMenuCoords = ConsoleField.MenuStartPossition;
                this.menues = this.menuCreator.GetMenues();
                renderer.Write(this.menues);

                Coordinates currentCursorCoords = new Coordinates(ConsoleField.MenuStartPossition.Row, currentMenuCoords.Col - CursorDistance);
                Coordinates cursorCoordinates = cursor.Move(this.menues, currentCursorCoords);

                IMenu currentMenu = this.menues.First(m => m.MenuCoordinates.Row == cursorCoordinates.Row
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
                    parameters[i] = this.renderer;
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
