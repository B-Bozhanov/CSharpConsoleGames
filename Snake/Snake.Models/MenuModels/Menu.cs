namespace Snake.Models.Menu
{

    using Snake.Common;
    using Snake.Models.Menu.Core;
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.Interfaces;
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    public abstract class Menu : IMenu
    {
        protected IRepository<string> namespaces;
        private readonly int MenuStartRow = ConsoleField.MenuStartPossition.Row;
        private readonly int MenuStartCol = ConsoleField.MenuStartPossition.Col;


        protected Menu(int menuNumber, IRepository<string> namespaces)
        {
            ID = menuNumber;
            this.namespaces = namespaces;
            // this.namespaces.Add(NameSpacesInfo.UserLoginMenu);
            MenuCoordinates = new Coordinates(MenuStartRow + ID - 1, MenuStartCol);
        }

        public abstract int ID { get; protected set; }

        public Coordinates MenuCoordinates { get; private set; }


        public virtual string GetName()
        {
            return this.GetType().Name;
        }

        protected string BackCommand()
        {
            namespaces.Remove();
            return namespaces.Get();
        }

        public virtual string Execute()
        {
            return null;
        }

        public virtual string Execute(IField field, IRenderer renderer)
        {
            return null;
        }

        public virtual string Execute(IRenderer renderer)
        {
            return null;
        }

        public virtual string Execute(IField field)
        {
            return null;
        }
    }
}
