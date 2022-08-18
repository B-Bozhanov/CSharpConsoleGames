namespace GameMenu.Core
{
    using System.Reflection;

    using Interfaces;
    using GameMenu.Models.Interfaces;
    using Snake.Utilities.Interfaces;

    internal class Interpretor : IInterpretor
    {
        private readonly Assembly assembly;

        public Interpretor()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        public HashSet<IMenu> GetMenues(Type type, ICoordinates menuCoords)
        {
            var menues = new HashSet<IMenu>();
            var types = assembly
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(type));

            foreach (var interfacesType in types)
            {
                object currentMenu = Activator.CreateInstance(interfacesType, menuCoords.Row, menuCoords.Col);
                menues.Add((IMenu)currentMenu);
            }

            var sortedMenues = menues
                .OrderBy(m => m.MenuNumber)
                .ToHashSet();

            return sortedMenues;
        }
    }
}
