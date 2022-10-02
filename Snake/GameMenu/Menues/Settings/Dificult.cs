using GameMenu.IO.Interfaces;
using GameMenu.Repository.Interfaces;

namespace GameMenu.Menues.Settings
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class Dificult : Menu
    {
        private const int SequenceNumber = 3;
        public Dificult(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override int ID { get; protected set; }

        public override string Execute()
        {
            return null;
        }
    }
}
