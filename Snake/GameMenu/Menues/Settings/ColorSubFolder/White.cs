namespace GameMenu.Menues.Settings.ColorSubFolder
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class White : Menu, IColor
    {
        private const int SequenceNumber = 1;


        public override int MenuNumber { get; protected set; }

        public Color FieldColor { get; } = Color.White;

        public Color TextColor { get; } = Color.Black;

        public White(int row, int col, IRepository<string> namespaces)
            : base(SequenceNumber, row, col, namespaces)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            field.ResetColor();
            field.SetBackgroundColor(this.FieldColor);
            field.SetTextColor(this.TextColor);
            base.BackCommand();
            return null;
        }
    }
}
