namespace GameMenu.Models
{
    using System;
    using GameMenu.Repository;
    using GameMenu.Repository.Interfaces;
    using Interfaces;
    using Snake.Utilities;

    public abstract class Menu : IMenu
    {
        private int menuNumber;
        protected IRepository<string> namespaces;

        protected Menu(int menuNumber, int row, int col, IRepository<string> namespaces)
        {
            MenuNumber = menuNumber;
            MenuCoordinates = new Coordinates();
            this.namespaces = namespaces;
            MenuCoordinates.Row = row + MenuNumber - 1;
            MenuCoordinates.Col = col;
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
