namespace GameMenu.Menues.UserLoginMenu
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.UserInputHandle.Interfaces;
    using GameMenu.UserInputHandle;
    using GameMenu.Menues.Interfaces;

    internal class Quit : Menu
    {
        private const string QuestionMessage = "Are you sure ? --> Y / N";
        private const string GoodByeMessage = "Good bye !";
        private const int SequenceNumber = 5;

        private readonly IUserInput input;

        public Quit(int row, int col, IRepository<string> namespaces)
            : base(SequenceNumber, row, col, namespaces)
        {
            this.input = new UserInput();
        }
        public Quit(int menuNumber, int row, int col, IRepository<string> namespaces)
            : base(menuNumber, row, col, namespaces)
        {
            this.input = new UserInput();
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field, IWriter writer, IReader reader)
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

            return this.namespaces.Get();
        }
    }
}
