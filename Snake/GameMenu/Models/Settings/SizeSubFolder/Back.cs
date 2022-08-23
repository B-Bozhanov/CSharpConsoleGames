using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.Settings.SizeSubFolder
{
    internal class Back : Menu
    {
        private const int Number = 4;

        public Back(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }
    }
}
