namespace Snake.Models.Menu.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public void Add(T entity);

        public T Remove();

        public T Get();
    }
}
