using GameMenu.Core.Interfaces;
using GameMenu.IO.Interfaces;
using GameMenu.Repository.Interfaces;

namespace GameMenu.Menues.Settings
{
    internal class Back : Menu
    {
        private const int SequenceNumber = 4;

        public Back(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override int ID { get; protected set; }

        public override string Execute()
        {
            this.BackCommand();
            return null;
        }
    }
}
