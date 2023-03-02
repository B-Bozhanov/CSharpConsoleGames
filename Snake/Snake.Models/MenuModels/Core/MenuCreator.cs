namespace Snake.Models.Menu.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Snake.Common;
    using Snake.Models.Menu.Interfaces;
    using Snake.Models.Menu.MainMenu;
    using Snake.Models.Menu.Repository.Interfaces;
    using Snake.Models.Menu.UserLoginMenu;

    using UserDatabase.Interfaces;

    public class MenuCreator : IMenuCreator
    {
        private readonly IRepository<string> namespaces;
        private readonly IDatabase usersDatabase;
        private Coordinates menuStartCoords;

        public MenuCreator(IRepository<string> namespaces, IDatabase usersDatabse)
        {
            this.namespaces = namespaces;
            usersDatabase = usersDatabse;
            menuStartCoords = new Coordinates();
        }

        public ICollection<IMenu> GetMenues()
        {
            var menues = new HashSet<IMenu>();
            menuStartCoords.Row = -1;
            menuStartCoords.Col = -1;

            Type[] types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Namespace == namespaces.Get())
                .ToArray();

            object[] constructorWithUsersArgs = new object[] { namespaces, usersDatabase };
            object[] defaultConstructorArgs = new object[] { namespaces };

            foreach (var type in types)
            {
                IMenu currentMenu;
                if (type == typeof(Login)
                    || type == typeof(CreateAccount)
                    || type == typeof(ContinueWithoutAccount)
                    || type == typeof(Logout))
                {
                    currentMenu = (IMenu)Activator.CreateInstance(type, constructorWithUsersArgs)!;
                }
                else
                {
                    currentMenu = (IMenu)Activator.CreateInstance(type, defaultConstructorArgs)!;
                }

                menues.Add(currentMenu);
            }

            var sortedMenues = menues
                .OrderBy(m => m.ID)
                .ToHashSet();

            return sortedMenues;
        }
    }
}
