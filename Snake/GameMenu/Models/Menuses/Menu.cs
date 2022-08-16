namespace GameMenu.Models.Menuses
{
    using System;

    using Interfaces;
    using Snake.Utilities;

    public abstract class Menu : IMenu
    {
        private int menuNumber;

        protected Menu()
        {
            string currNamespace = this.GetType().Namespace;

            if (!NameSpaces.Namespaces.Contains(currNamespace))
            {
                NameSpaces.Namespaces.Push(currNamespace);
            }
        }
        protected Menu(int menuNumber, int row, int col)
            : this()
        {
            this.MenuNumber = menuNumber;
            this.MenuCoordinates = new Coordinates();
            this.MenuCoordinates.Row = row + this.MenuNumber - 1;
            this.MenuCoordinates.Col = col;
        }

        public int MenuNumber
        {
            get => this.menuNumber;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Menu number must be possitive!");
                }
                this.menuNumber = value;
            }
        }

        public Coordinates MenuCoordinates { get; private set; }

        public abstract string Execute();

        public virtual string GetName()
        {
            return this.GetType().Name;
        }

        protected string BackCommand()
        {
            NameSpaces.Pop();
            return NameSpaces.Peek();
        }
    }
}
