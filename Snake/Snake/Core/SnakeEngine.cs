namespace Snake.Core
{
    using GameMenu.Menues.Interfaces;
    using Snake.Core.Interfaces;
    using UserDatabase.Interfaces;

    public class SnakeEngine : ISnakeEngine
    {
        private IAccount user;
        private IField field;
        public SnakeEngine(IAccount user, IField field)
        {
            this.user = user;
            this.field = field;
        }
        public void StartGame()
        {
            Random random = new Random();
            var fakepoints = random.Next(1, 1000);
            Console.WriteLine("Game is started!");

            this.user.Score = fakepoints;
           // return this.user;
        }
    }
}
