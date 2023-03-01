namespace Snake.Models.Menu.Settings.ColorSubFolder
{
    using Snake.Models.Menu;
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    internal class Black : Menu, IColor
    {
        private const int SequenceNumber = 2;

        public Black(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }


        public override int ID { get; protected set; }

        public Color FieldColor => throw new NotImplementedException();

        public Color TextColor => throw new NotImplementedException();

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute(IField field)
        {
            field.ResetColor();
            BackCommand();
            return null;
        }
    }
}
