namespace GameMenu.Models.UserLoginMenu
{
    using GameMenu.Repository.Interfaces;

    internal class About : Menu
    {
        private const int MenuNumber = 4;

        public About(int row, int col, IRepository<string> namespaces)
            : base(MenuNumber, row, col, namespaces)
        {
        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
