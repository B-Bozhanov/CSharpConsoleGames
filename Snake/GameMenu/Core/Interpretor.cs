namespace GameMenu.Core
{
    using System.Reflection;

    using Interfaces;
    using GameMenu.Models.Interfaces;
    using Snake.Utilities.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class Interpretor : IInterpretor<string, ICoordinates>
    {
        private readonly Assembly assembly;

        public Interpretor()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        public HashSet<IMenu> GetMenues(IRepository<string> namespaces, ICoordinates menuCoords)
        {
            var menues = new HashSet<IMenu>();

            Type[] types = assembly
                .GetTypes()
                .Where(t => t.Namespace == namespaces.Peek())
                .ToArray();
            var test = types[0];

            foreach (var type in types)
            {
                IMenu currentMenu = (IMenu)Activator.CreateInstance(type, new object[] { menuCoords.Row, menuCoords.Col, namespaces });
                menues.Add(currentMenu);
            }

            var sortedMenues = menues
                .OrderBy(m => m.MenuNumber)
                .ToHashSet();

            return sortedMenues;
        }
    }
}
