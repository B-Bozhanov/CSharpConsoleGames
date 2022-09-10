using GameMenu.Menues.Interfaces;
using GameMenu.Repository.Interfaces;
using GameMenu.Utilities;

namespace GameMenu.Menues.Settings
{
    internal class ScreenSize : Menu
    {
        private const int Number = 1;
        public ScreenSize(int row, int col,IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string GetName()
        {
            return "Screen Size";
        }
        public override string Execute(IField field)
        {
            this.namespaces.Add(NameSpacesInfo.ScreenSize);
            return this.namespaces.Get(); 
        }
    }
}

