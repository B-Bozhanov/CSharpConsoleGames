using GameMenu.Menues.Interfaces;
using GameMenu.Repository.Interfaces;

namespace GameMenu.Menues.Settings
{
    internal class Dificult : Menu
    {
        private const int Number = 3;
        public Dificult(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field)
        {
            throw new NotImplementedException();
        }
    }
}
