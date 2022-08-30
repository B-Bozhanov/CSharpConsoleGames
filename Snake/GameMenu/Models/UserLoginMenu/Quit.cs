namespace GameMenu.Models.UserLoginMenu
{
    using GameMenu.IO.Interfaces;
    using GameMenu.IO;
    using GameMenu.Repository.Interfaces;
    using GameMenu.UserInputHandle.Interfaces;
    using GameMenu.UserInputHandle;

    internal class Quit : Menu
    {
        private const string QuestionMessage = "Are you sure ? --> Y / N";
        private const string GoodByeMessage = "Good bye !";
        private const int MenuNumber = 5;

        private readonly IWriter writer;
        private readonly IUserInput input;

        public Quit(int row, int col, IRepository<string> namespaces)
            : base(MenuNumber, row, col, namespaces)
        {
            this.writer = new ConsoleWriter();
            this.input = new UserInput();
        }
        public Quit(int menuNumber, int row, int col, IRepository<string> namespaces)
            : base(menuNumber, row, col, namespaces)
        {
            this.writer = new ConsoleWriter();
            this.input = new UserInput();
        }

        public override string Execute()
        {
            this.writer.Clear();
            this.writer.Write(QuestionMessage, this.MenuCoordinates.Row, this.MenuCoordinates.Col);

            while (true)
            {
                var key = input.GetInput();
                if (key == KeyPressed.Yes)
                {
                    this.writer.Clear();
                    this.writer.Write(GoodByeMessage, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                    Thread.Sleep(3000);
                    this.namespaces.Pop();
                    Environment.Exit(0);
                }
                else if (key == KeyPressed.No)
                {
                    break;
                }
            }

            return this.namespaces.Peek();
        }
    }
}
