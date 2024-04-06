namespace Snake.Services
{
    using System.Reflection;

    using Snake.Services.Interfaces;

    using Common;

    public class MenuService : IMenuService
    {
        private readonly Assembly menuesAssembly;
        private Stack<string> namespaces;

        public MenuService()
        {
            this.menuesAssembly = Assembly.Load(GlobalConstants.Menu.MenuAssemblyName)
                ?? throw new ArgumentNullException(GlobalConstants.Exceptions.Menu.AssemblyNotFound);

            var menuType = this.menuesAssembly.GetTypes().FirstOrDefault(x => x.Name == GlobalConstants.Menu.StartMenuTypeName)
                ?? throw new ArgumentNullException(GlobalConstants.Exceptions.Menu.TypeNotFound);

            string firstNamespace = this.GetMenuNamespace(menuType);

            this.namespaces = new Stack<string>();
            this.namespaces.Push(firstNamespace);
        }

        private void AddNamespace(Type menuType)
        {
            string currentNamespace = this.GetMenuNamespace(menuType);
            this.namespaces.Push(currentNamespace);
        }

        private string GetMenuNamespace(Type menuType)
        {
            var menuesNamespace = this.menuesAssembly
                                        .GetTypes()?
                                        .FirstOrDefault(x => x.Name == menuType.Name)?.FullName 
                                        ?? throw new ArgumentNullException(GlobalConstants.Exceptions.Menu.NamespaceNotFound);

            var lastIndex = menuesNamespace.Length - menuType.Name.Length - 1; // 1 is '.'
            return menuesNamespace.Substring(0, lastIndex);
        }

        public HashSet<T> Create<T>()
        {
            IEnumerable<Type> types = this.menuesAssembly.GetTypes().Where(x => x.Namespace == this.namespaces.Peek());

            var menues = new HashSet<T>();

            foreach (var type in types)
            {
                var currentMenuInstance = (T)Activator.CreateInstance(type, new object[] { type.Name })!;
                menues.Add(currentMenuInstance);
            }

            return menues;
        }
    }
}
