namespace GameMenu.Menues
{
    using System;
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;
    using Interfaces;

    public abstract class Menu : IMenu
    {
        protected IRepository<string> namespaces;

        protected Menu(int menuNumber, int row, int col, IRepository<string> namespaces)
        {
            this.MenuNumber = menuNumber;
            this.MenuCoordinates = new Coordinates(row + MenuNumber - 1, col);
            this.namespaces = namespaces;
        }

        public abstract int MenuNumber { get; protected set; }

        public Coordinates MenuCoordinates { get; private set; }

        
        public abstract string Execute(IField field, IWriter writer, IReader reader);

        public virtual string GetName()
        {
            return this.GetType().Name;
        }

        protected string BackCommand()
        {
            this.namespaces.Remove();
            return this.namespaces.Get();
        }

        public string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
