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
            var _interface = this.GetType();

            if (!InterfaceRepository<Type>.Interfaces.Contains(_interface))
            {
                InterfaceRepository<Type>.Interfaces.Push(_interface);
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

        public virtual Type Execute()
        {
            return this.GetType();
           // return this.BackCommand();
        }

        public virtual string GetName()
        {
            return this.GetType().Name;
        }

        protected Type BackCommand()
        {
            InterfaceRepository<Type>.Pop();
            return InterfaceRepository<Type>.Peek();
        }
    }
}
