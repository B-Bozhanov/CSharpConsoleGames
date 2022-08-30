using GameMenu.Repository.Interfaces;
using GameMenu.Utilities;

namespace GameMenu.Models.Settings
{
    internal class ScreenSize : Menu
    {
        private const int Number = 1;
        public ScreenSize(int row, int col,IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override string GetName()
        {
            return "Screen Size";
        }
        public override string Execute()
        {
            this.namespaces.Add(NameSpacesInfo.ScreenSize);
            return this.namespaces.Get(); 
        }
    }
}

