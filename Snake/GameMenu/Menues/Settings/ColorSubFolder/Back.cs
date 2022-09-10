namespace GameMenu.Menues.Settings.ColorSubFolder
{
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class Back : Menu
    {
        private const int SequenceNumber = 4;
        public Back(int row, int col, IRepository<string> namespaces)
            : base(SequenceNumber, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field)
        {
            return this.BackCommand();
        }
    }
}
