using GameMenu.IO.Interfaces;
using GameMenu.Repository.Interfaces;

namespace GameMenu.Menues.Settings.SizeSubFolder
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class Back : Menu
    {
        private const int Number = 4;

        public Back(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            this.BackCommand();
            return null;
        }
    }
}
