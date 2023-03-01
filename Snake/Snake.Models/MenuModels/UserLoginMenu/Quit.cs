namespace Snake.Models.Menu.UserLoginMenu
{
    using System;
    using System.Threading;

    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;
    using Snake.Models.Menu.UserInputHandle;
    using Snake.Models.Menu.UserInputHandle.Interfaces;

    internal class Quit : Menu
    {
        private const string QuestionMessage = "Are you sure? --> Y / N";
        private const string GoodByeMessage = "Good bye!";
        private const int SequenceNumber = 5;

        private readonly IUserInput input;

        public Quit(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
            input = new UserInput();
        }
        public Quit(int menuNumber, IRepository<string> namespaces)
            : base(menuNumber, namespaces)
        {
            input = new UserInput();
        }

        public override int ID { get; protected set; }

        public override string Execute(IRenderer renderer)
        {
            renderer.Clear();
            renderer.Write(QuestionMessage, MenuCoordinates.Row, MenuCoordinates.Col);

            while (true)
            {
                var key = input.GetInput();
                if (key == KeyPressed.Yes)
                {
                    renderer.Clear();
                    renderer.Write(GoodByeMessage, MenuCoordinates.Row, MenuCoordinates.Col);
                    Thread.Sleep(3000);
                    namespaces.Remove();
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
