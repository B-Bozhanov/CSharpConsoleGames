namespace Snake.Models.Menu.MainMenu
{
    using System.Threading;

    using Snake.Models.Menu;
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    internal class NewGame : Menu
    {
        private const int SequenceNumber = 1;


        public NewGame(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override int ID { get; protected set; }


        public override string GetName()
        {
            return "New Game";
        }
        public override string Execute(IRenderer renderer)
        {
            int timer = 1;
            renderer.Clear();

            while (timer != 0)
            {
                renderer.Write(timer.ToString(), MenuCoordinates.Row, MenuCoordinates.Col);
                timer--;
                Thread.Sleep(1000);
            }
            renderer.Clear();
            return "NewGame";
        }
    }
}
