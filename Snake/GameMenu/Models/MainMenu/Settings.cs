namespace GameMenu.Models.MainMenu
{
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;

    internal class Settings : Menu
    {
        private const int Number = 2;

        public Settings(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override string Execute()
        {
            this.namespaces.Push(NameSpacesInfo.Settings);
            return this.namespaces.Peek(); 
        }
    }
}
