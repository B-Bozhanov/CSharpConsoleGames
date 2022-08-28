using GameMenu.Models.Interfaces;
using GameMenu.Repository.Interfaces;
using Snake.Utilities;
using Snake.Utilities.Interfaces;

namespace GameMenu.Repository
{
    internal class NameSpaceRepository : IRepository<string>
    {
        private readonly HashSet<string> namespaces;

        public NameSpaceRepository()
        {
            this.namespaces = new HashSet<string>();
        }

        public void Push(string entity)
        {
            this.namespaces.Add(entity);
        }

        public string Pop()
        {
            var lastElement = this.namespaces.Last();
            this.namespaces.Remove(lastElement);
            return lastElement;
        }

        public string Peek()
        {
            var lastElement = this.namespaces.Last();
            return lastElement;
        }
    }
}
