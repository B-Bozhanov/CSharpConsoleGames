namespace GameMenu.Menues.Settings.ColorSubFolder
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;

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
            base.BackCommand();
            return null;
        }
    }
}
