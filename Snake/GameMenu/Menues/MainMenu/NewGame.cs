namespace GameMenu.Menues.MainMenu
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues;
    using GameMenu.Repository.Interfaces;


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
            int timer = 5;
            renderer.Clear();

            while (timer != 0)
            {
                renderer.Write(timer.ToString(), this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                timer--;
                Thread.Sleep(1000);
            }
            renderer.Clear();
            return "NewGame";
        }
    }
}
