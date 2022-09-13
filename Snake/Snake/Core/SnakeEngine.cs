namespace Snake.Core
{
    using Snake.Core.Interfaces;
    using UserDatabase.Interfaces;

    public class SnakeEngine : ISnakeEngine
    {
        private IUser user;
        public SnakeEngine(IUser user)
        {
            this.user = user;
        }
        public void StartGame()
        {
            Console.WriteLine("Game is started!");

                if (user.Username == "Bozhan")
                {
                    user.Score += 20;
                }
                else
                {
                    user.Score = 10;
                }
        }
    }
}
