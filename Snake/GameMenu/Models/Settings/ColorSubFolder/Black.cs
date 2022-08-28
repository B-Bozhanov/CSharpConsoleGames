using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.Settings.ColorSubFolder
{
    internal class Black : Menu
    {
        private const int Number = 2;

        public Black(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute()
        {
            Console.ResetColor();
            return base.BackCommand();
        }
    }
}
