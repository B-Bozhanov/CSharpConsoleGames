namespace Snake.Models.Menu.UserLoginMenu
{
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    internal class About : Menu
    {
        private const int SequenceNumber = 4;

        public About(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override int ID { get; protected set; }

        public override string Execute(IRenderer renderer)
        {
            renderer.Clear();
            renderer.Write("This is abaut!", MenuCoordinates.Row, MenuCoordinates.Col);
            Thread.Sleep(5000);
            return null;
        }
    }
}
