namespace GameMenu.Menues.UserLoginMenu
{
using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class About : Menu
    {
        private const int SequenceNumber = 4;

        public About(int row, int col, IRepository<string> namespaces)
            : base(SequenceNumber, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
