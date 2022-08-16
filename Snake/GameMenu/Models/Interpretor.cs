namespace GameMenu.Models
{
    using Interfaces;
    using System.Reflection;

    internal class Interpretor : IInterpretor
    {
        private readonly Assembly assembly;

        public Interpretor()
        {
            this.assembly = Assembly.GetExecutingAssembly();
        }

        public HashSet<IMenu> GetMenues(string namespaces, int row, int col)
        {
            var menues = new HashSet<IMenu>();

            Type[] types = assembly
                .GetTypes()
                .Where(t => t.Namespace == namespaces)
                .ToArray();

            foreach (var type in types)
            {
                object currentMenu = Activator.CreateInstance(type, row, col);
                menues.Add((IMenu)currentMenu);
            }

            var sortedMenues = menues.OrderBy(m => m.MenuNumber).ToHashSet();
            return sortedMenues;
        }
    }
}
