namespace GameMenu.Menues.MainMenu
{
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;

    internal class Settings : Menu
    {
        private const int Number = 2;

        public Settings(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field)
        {
            this.namespaces.Add(NameSpacesInfo.Settings);
            return this.namespaces.Get(); 
        }
    }
}
