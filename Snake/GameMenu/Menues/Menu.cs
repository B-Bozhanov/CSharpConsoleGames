namespace GameMenu.Menues
{
    using System;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;
    using Interfaces;
    using Snake.Utilities;

    public abstract class Menu : IMenu
    {
        protected IRepository<string> namespaces;

        protected Menu(int menuNumber, int row, int col, IRepository<string> namespaces)
        {
            this.MenuNumber = menuNumber;
            this.MenuCoordinates = new Coordinates();
            this.namespaces = namespaces;
            this.MenuCoordinates.Row = row + MenuNumber - 1;
            this.MenuCoordinates.Col = col;
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
