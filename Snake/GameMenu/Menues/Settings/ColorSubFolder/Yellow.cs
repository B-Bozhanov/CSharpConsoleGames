namespace GameMenu.Menues.Settings.ColorSubFolder
{
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;

    public class Yellow : Menu, IColor
    {
        private const int Number = 3;

        public Yellow(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public Color FieldColor { get; } = Color.Yellow;

        public Color TextColor { get; } = Color.Black;

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute(IField field)
        {
            field.SetBackgroundColor(this.FieldColor);
            field.SetTextColor(this.TextColor);

            return base.BackCommand();
        }
    }
}
