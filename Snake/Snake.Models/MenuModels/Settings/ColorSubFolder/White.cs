namespace Snake.Models.Menu.Settings.ColorSubFolder
{
    using Snake.Models.Menu;
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    internal class White : Menu, IColor
    {
        private const int SequenceNumber = 1;


        public override int ID { get; protected set; }

        public Color FieldColor { get; } = Color.White;

        public Color TextColor { get; } = Color.Black;

        public White(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute(IField field)
        {
            field.ResetColor();
            field.SetBackgroundColor(FieldColor);
            field.SetTextColor(TextColor);
            BackCommand();
            return null;
        }
    }
}
