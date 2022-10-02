using GameMenu.Core.Interfaces;
using GameMenu.IO.Interfaces;
using GameMenu.Repository.Interfaces;
using GameMenu.Utilities;

namespace GameMenu.Menues.Settings
{
    internal class ScreenSize : Menu
    {
        private const int SequenceNumber = 1;
        public ScreenSize(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override int ID { get; protected set; }

        public override string GetName()
        {
            return "Screen Size";
        }
        public override string Execute()
        {
            this.namespaces.Add(NameSpacesInfo.ScreenSize);
            return null;
        }
    }
}

