namespace GameMenu.Core
{
    using System.Reflection;

    using Interfaces;
    using GameMenu.Menues.Interfaces;
    using Snake.Utilities.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Menues.UserLoginMenu;
    using UserDatabase.Interfaces;
    using GameMenu.IO.Interfaces;

    internal class Interpretor : IInterpretor<string, ICoordinates>
    {
        private readonly Assembly assembly;

        public Interpretor()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        public HashSet<IMenu> GetMenues(IRepository<string> namespaces,
                                        ICoordinates menuCoords, IUserDatabase users)
        {
            var menues = new HashSet<IMenu>();

            Type[] types = assembly
                .GetTypes()
                .Where(t => t.Namespace == namespaces.Get())
                .ToArray();

            object[] constructorWithUsersArgs = new object[] { menuCoords.Row, menuCoords.Col, namespaces, users};
            object[] defaultConstructorArgs = new object[] { menuCoords.Row, menuCoords.Col, namespaces};

            foreach (var type in types)
            {
                IMenu currentMenu;
                if (type == typeof(Login) || type == typeof(CreateAccount) || type == typeof(ContinueWithoutAccount))
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
                .OrderBy(m => m.MenuNumber)
                .ToHashSet();

            return sortedMenues;
        }
    }
}
