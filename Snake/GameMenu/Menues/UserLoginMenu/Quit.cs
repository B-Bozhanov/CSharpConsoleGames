namespace GameMenu.Menues.UserLoginMenu
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.UserInputHandle.Interfaces;
    using GameMenu.UserInputHandle;
    using GameMenu.Core.Interfaces;

    internal class Quit : Menu
    {
        private const string QuestionMessage = "Are you sure? --> Y / N";
        private const string GoodByeMessage = "Good bye!";
        private const int SequenceNumber = 5;

        private readonly IUserInput input;

        public Quit(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
            this.input = new UserInput();
        }
        public Quit(int menuNumber, IRepository<string> namespaces)
            : base(menuNumber, namespaces)
        {
            this.input = new UserInput();
        }

        public override int ID { get; protected set; }

        public override string Execute(IWriter writer)
        {
            writer.Clear();
            writer.Write(QuestionMessage, this.MenuCoordinates.Row, this.MenuCoordinates.Col);

            while (true)
            {
                var key = input.GetInput();
                if (key == KeyPressed.Yes)
                {
                    writer.Clear();
                    writer.Write(GoodByeMessage, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                    Thread.Sleep(3000);
                    this.namespaces.Remove();
                    Environment.Exit(0);
                }
                else if (key == KeyPressed.No)
                {
                    break;
                }
            }

            return null;
        }
    }
}
