namespace Snake.Core
{
    using Snake.Core.Interfaces;

    public class SnakeEngine : ISnakeEngine
    {
        public void StartGame()
        {
            while (true)
            {
                Console.WriteLine("Game is started!");
            }
        }
    }
}
