namespace GameMenu.Menues.Settings
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;

    using Snake.Common;

    internal class FieldColor : Menu
    {
        private const int SequenceNumber = 2;

        public FieldColor(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override int ID { get; protected set; }

        public override string GetName()
        {
            return "Field Color";
        }
        public override string Execute()
        {
            this.namespaces.Add(NameSpacesInfo.FieldColor);
            return null;
        }
    }
}
