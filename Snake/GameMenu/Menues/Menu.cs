namespace GameMenu.Menues
{
    using GameMenu.Core;
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;
    using Interfaces;

    public abstract class Menu : IMenu
    {
        protected IRepository<string> namespaces;
        private readonly int MenuStartRow = ConsoleField.MenuStartPossition.Row;
        private readonly int MenuStartCol = ConsoleField.MenuStartPossition.Col;


        protected Menu(int menuNumber, IRepository<string> namespaces)
        {
            this.ID = menuNumber;
            this.namespaces = namespaces;
           // this.namespaces.Add(NameSpacesInfo.UserLoginMenu);
            this.MenuCoordinates = new Coordinates(MenuStartRow + ID - 1, MenuStartCol);
        }

        public abstract int ID { get; protected set; }

        public Coordinates MenuCoordinates { get; private set; }


        public virtual string GetName()
        {
            return this.GetType().Name;
        }

        protected string BackCommand()
        {
            this.namespaces.Remove();
            return this.namespaces.Get();
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
