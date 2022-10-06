using UserDatabase.Interfaces;

namespace Snake.Core.Interfaces
{
    public interface ISnakeEngine
    {
        void StartGame(IAccount account);
    }
}
