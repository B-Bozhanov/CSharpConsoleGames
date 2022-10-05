namespace Snake.Core.Interfaces
{
    using UserDatabase.Interfaces;

    public interface ISnakeEngine
    {
        void StartGame(IAccount account);
    }
}
