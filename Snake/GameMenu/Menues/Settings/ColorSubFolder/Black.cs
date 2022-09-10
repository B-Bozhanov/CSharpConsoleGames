namespace GameMenu.Menues.Settings.ColorSubFolder
{
    using GameMenu.Menues;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class Black : Menu, IColor
    {
        private const int SequenceNumber = 2;

        public Black(int row, int col, IRepository<string> namespaces)
            : base(SequenceNumber, row, col, namespaces)
        {
        }


        public override int MenuNumber { get; protected set; }

        public Color FieldColor => throw new NotImplementedException();

        public Color TextColor => throw new NotImplementedException();

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute(IField field)
        {
            field.ResetColor();
            return base.BackCommand();
        }
    }
}
