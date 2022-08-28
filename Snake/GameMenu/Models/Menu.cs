namespace GameMenu.Models
{
    using System;
    using Interfaces;
    using GameMenu.Repository.Interfaces;
    using Snake.Utilities;

    public abstract class Menu : IMenu
    {
        private int menuNumber;
        protected IRepository<string> namespaces;

        protected Menu(int menuNumber, int row, int col, IRepository<string> namespaces)
        {
            this.MenuNumber = menuNumber;
            this.MenuCoordinates = new Coordinates();
            this.namespaces = namespaces;
            this.MenuCoordinates.Row = row + MenuNumber - 1;
            this.MenuCoordinates.Col = col;
        }

        public int MenuNumber
        {
            get => menuNumber;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Menu number must be possitive!");
                }
                menuNumber = value;
            }
        }

        public Coordinates MenuCoordinates { get; private set; }

        public virtual string Execute()
        {
            return BackCommand();
        }

        public virtual string GetName()
        {
            return GetType().Name;
        }

        protected string BackCommand()
        {
            this.namespaces.Pop();
            return this.namespaces.Peek();
        }
    }
}
