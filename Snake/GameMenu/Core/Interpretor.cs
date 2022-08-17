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

        public HashSet<IMenu> GetMenues(string namespaces, ICoordinates menuCoords)
        {
            var menues = new HashSet<IMenu>();

            Type[] types = assembly
                .GetTypes()
                .Where(t => t.Namespace == namespaces)
                .ToArray();

            foreach (var type in types)
            {
                object currentMenu = Activator.CreateInstance(type, menuCoords.Row, menuCoords.Col);
                menues.Add((IMenu)currentMenu);
            }

            var sortedMenues = menues
                .OrderBy(m => m.MenuNumber)
                .ToHashSet();

            return sortedMenues;
        }
    }
}
