using GameMenu.Menues.Interfaces;
using Snake.Utilities.Interfaces;

namespace GameMenu.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public void Add(T entity);
        public T Remove();
        public T Get();
    }
}
