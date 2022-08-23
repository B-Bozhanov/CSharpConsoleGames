using GameMenu.Models.Interfaces;
using Snake.Utilities.Interfaces;

namespace GameMenu.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public void Push(T entity);
        public T Pop();
        public T Peek();
    }
}
