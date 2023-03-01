namespace GameMenu.Core
{
    using System.Collections.Generic;
    using System.Reflection;

    using GameMenu.Core.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Menues.MainMenu;
    using GameMenu.Menues.UserLoginMenu;
    using GameMenu.Repository.Interfaces;

    using Snake.Common;

    using UserDatabase.Interfaces;

    public class MenuCreator : IMenuCreator
    {
        private readonly IRepository<string> namespaces;
        private readonly IDatabase usersDatabase;
        private Coordinates menuStartCoords;

        public MenuCreator(IRepository<string> namespaces, IDatabase usersDatabse)
        {
            this.namespaces = namespaces;
            this.usersDatabase = usersDatabse;
            this.menuStartCoords = new Coordinates();
        }

        public ICollection<IMenu> GetMenues()
        {
            var menues = new HashSet<IMenu>();
            this.menuStartCoords.Row = -1;
            this.menuStartCoords.Col = -1;

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
