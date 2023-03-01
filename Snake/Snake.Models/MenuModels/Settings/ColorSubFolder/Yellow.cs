namespace Snake.Models.Menu.Settings.ColorSubFolder
{
    using Snake.Models.Menu;
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    public class Yellow : Menu, IColor
    {
        private const int SequenceNumber = 3;

        public Yellow(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override int ID { get; protected set; }

        public Color FieldColor { get; } = Color.Yellow;

        public Color TextColor { get; } = Color.Black;

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute(IField field)
        {
            field.SetBackgroundColor(FieldColor);
            field.SetTextColor(TextColor);

            BackCommand();
            return null;
        }
    }
}
