namespace Snake.Models.Menu.Settings
{
    using Snake.Models.Menu.Repository.Interfaces;

    internal class Back : Menu
    {
        private const int SequenceNumber = 4;

        public Back(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override int ID { get; protected set; }

        public override string Execute()
        {
            BackCommand();
            return null;
        }
    }
}
