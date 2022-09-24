namespace Snake.Core
{
    using Snake.Core.Interfaces;
    using UserDatabase.Interfaces;

    public class SnakeEngine : ISnakeEngine
    {
        private IAccount user;
        public SnakeEngine(IAccount user)
        {
            this.user = user;
        }
        public void StartGame()
        {
            Random random = new Random();
            var fakepoints = random.Next(1, 1000);
            Console.WriteLine("Game is started!");

            this.user.Score = fakepoints;
        }
    }
}
