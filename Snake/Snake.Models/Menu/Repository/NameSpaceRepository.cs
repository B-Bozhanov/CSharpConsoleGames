namespace Snake.Models.Menu.Repository
{
    using Snake.Models.Menu.Repository.Interfaces;

    public class NameSpaceRepository : IRepository<string>
    {
        private readonly HashSet<string> namespaces;

        public NameSpaceRepository()
        {
            namespaces = new HashSet<string>();
        }

        public void Add(string entity)
        {
            namespaces.Add(entity);
        }

        public string Remove()
        {
            var lastElement = namespaces.Last();
            namespaces.Remove(lastElement);
            return lastElement;
        }

        public string Get()
            => namespaces.Last();
    }
}
