namespace GameMenu.Models.Menuses.MainMenu
{
    using GameMenu.IO;
    using GameMenu.IO.Interfaces;
    using GameMenu.UserInputHandle;
    using GameMenu.UserInputHandle.Interfaces;
    using Interfaces;

    internal class Exit : Menu
    {
        private const string QuestionMessage = "Are you sure ? --> Y / N";
        private const string GoodByeMessage = "Good bye !";
        private const int Number = 3;
        private readonly IWriter writer;
        private readonly IUserInput input;

        public Exit(int row, int col)
            : base(Number, row, col)
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
                    NameSpaces.Pop();
                    Environment.Exit(0);
                }
                else if (key == KeyPressed.No)
                {
                    break;
                }
            }

            return NameSpaces.Peek();
        }
    }
}
