namespace Snake.Common.Exceptions
{
    public class GameOverException : Exception
    {
        public GameOverException() : base()
        {
        }

        public GameOverException(string message) : base(message)
        {
        }

        public GameOverException(string message, Exception e) : base(message, e)
        {
        }

        public string Exception { get; private set; }
    }
}
