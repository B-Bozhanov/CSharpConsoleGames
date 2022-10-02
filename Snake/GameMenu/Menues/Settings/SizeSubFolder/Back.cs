using GameMenu.IO.Interfaces;
using GameMenu.Repository.Interfaces;

namespace GameMenu.Menues.Settings.SizeSubFolder
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class Back : Menu
    {
        private const int Number = 4;

        public Back(IRepository<string> namespaces)
            : base(Number, namespaces)
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
