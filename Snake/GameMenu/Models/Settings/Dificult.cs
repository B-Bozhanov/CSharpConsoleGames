using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.Settings
{
    internal class Dificult : Menu
    {
        private const int Number = 3;
        public Dificult(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
