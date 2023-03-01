namespace Snake.Models.Menu.Settings
{
    using Snake.Common;
    using Snake.Models.Menu.Repository.Interfaces;

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
            namespaces.Add(NameSpacesInfo.FieldColor);
            return null;
        }
    }
}
