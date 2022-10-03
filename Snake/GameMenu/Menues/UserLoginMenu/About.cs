namespace GameMenu.Menues.UserLoginMenu
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;

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
            renderer.Write("This is abaut!", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            Thread.Sleep(5000);
            return null;
        }
    }
}
