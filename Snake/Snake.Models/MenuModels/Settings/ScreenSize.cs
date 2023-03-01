namespace Snake.Models.Menu.Settings
{
    using Snake.Common;
    using Snake.Models.Menu.Repository.Interfaces;

    internal class ScreenSize : Menu
    {
        private const int SequenceNumber = 1;
        public ScreenSize(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override int ID { get; protected set; }

        public override string GetName()
        {
            return "Screen Size";
        }
        public override string Execute()
        {
            namespaces.Add(NameSpacesInfo.ScreenSize);
            return null;
        }
    }
}

