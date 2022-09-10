﻿namespace GameMenu.Core
{
    using System.Reflection;

    using Interfaces;
    using GameMenu.Menues.Interfaces;
    using Snake.Utilities.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Menues.UserLoginMenu;
    using UserDatabase.Interfaces;

    internal class Interpretor : IInterpretor<string, ICoordinates>
    {
        private readonly Assembly assembly;

        public Interpretor()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        public HashSet<IMenu> GetMenues(IRepository<string> namespaces, ICoordinates menuCoords, IUserDatabase users)
        {
            var menues = new HashSet<IMenu>();

            Type[] types = assembly
                .GetTypes()
                .Where(t => t.Namespace == namespaces.Get())
                .ToArray();
            var test = types[0];

            foreach (var type in types)
            {
                IMenu currentMenu;
                if (type == typeof(Login) || type == typeof(CreateAccount))
                {
                    currentMenu = (IMenu)Activator.CreateInstance(type, new object[] { menuCoords.Row, menuCoords.Col, namespaces, users})!;
                }
                else
                {
                    currentMenu = (IMenu)Activator.CreateInstance(type, new object[] { menuCoords.Row, menuCoords.Col, namespaces })!;
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
