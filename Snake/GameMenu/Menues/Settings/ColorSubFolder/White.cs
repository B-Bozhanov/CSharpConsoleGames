using GameMenu.Menues.Interfaces;
namespace GameMenu.Menues.Settings.ColorSubFolder
{
    using GameMenu.Repository.Interfaces;

    internal class White : Menu, IColor
    {
        private const int Number = 1;


        public override int MenuNumber { get; protected set; }

        public Color FieldColor { get; } = Color.White;

        public Color TextColor { get; } = Color.Black;

        public White(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute(IField field)
        {
            field.ResetColor();
            field.SetBackgroundColor(this.FieldColor);
            field.SetTextColor(this.TextColor);
            return base.BackCommand();
        }
    }
}
