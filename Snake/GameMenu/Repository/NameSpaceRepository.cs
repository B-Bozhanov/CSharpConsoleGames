namespace GameMenu.Repository
{
    using GameMenu.Repository.Interfaces;

    public class NameSpaceRepository : IRepository<string>
    {
        private readonly HashSet<string> namespaces;

        public NameSpaceRepository()
        {
            this.namespaces = new HashSet<string>();
        }

        public void Add(string entity)
        {
            this.namespaces.Add(entity);
        }

        public string Remove()
        {
            var lastElement = this.namespaces.Last();
            this.namespaces.Remove(lastElement);
            return lastElement;
        }

        public string Get()
        {
            var lastElement = this.namespaces.Last();
            return lastElement;
        }
    }
}
