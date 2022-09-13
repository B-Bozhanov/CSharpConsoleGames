namespace GameMenu.Menues.Settings
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;

    internal class FieldColor : Menu
    {
        private const int SequenceNumber = 2;

        public FieldColor(int row, int col, IRepository<string> namespaces)
            : base(SequenceNumber, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string GetName()
        {
            return "Field Color";
        }
        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            this.namespaces.Add(NameSpacesInfo.FieldColor);
            return this.namespaces.Get(); ;
        }
    }
}
