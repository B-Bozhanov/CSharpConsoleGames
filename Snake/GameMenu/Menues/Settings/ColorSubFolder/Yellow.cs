namespace GameMenu.Menues.Settings.ColorSubFolder
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;

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
            field.SetBackgroundColor(this.FieldColor);
            field.SetTextColor(this.TextColor);

            base.BackCommand();
            return null;
        }
    }
}
