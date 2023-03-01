namespace Snake.Models.Menu.Settings.SizeSubFolder
{
    using Snake.Models.Menu.Repository.Interfaces;

    internal class Back : Menu
    {
        private const int Number = 4;

        public Back(IRepository<string> namespaces)
            : base(Number, namespaces)
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
