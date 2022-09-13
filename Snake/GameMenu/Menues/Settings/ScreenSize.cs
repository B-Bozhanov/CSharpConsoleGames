using GameMenu.IO.Interfaces;
using GameMenu.Menues.Interfaces;
using GameMenu.Repository.Interfaces;
using GameMenu.Utilities;

namespace GameMenu.Menues.Settings
{
    internal class ScreenSize : Menu
    {
        private const int SequenceNumber = 1;
        public ScreenSize(int row, int col,IRepository<string> namespaces)
            : base(SequenceNumber, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string GetName()
        {
            return "Screen Size";
        }
        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            this.namespaces.Add(NameSpacesInfo.ScreenSize);
            return this.namespaces.Get(); 
        }
    }
}

