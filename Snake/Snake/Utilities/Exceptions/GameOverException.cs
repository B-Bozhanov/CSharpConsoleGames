namespace Snake.Utilities.Exceptions
{
    internal class GameOverException : Exception
    {
        internal GameOverException() : base()
        {
        }

        internal GameOverException(string message) : base(message)
        { 
        }

        internal GameOverException(string message, Exception e) : base(message, e) 
        {
        }

        public string Exception { get; private set; }
    }
}
