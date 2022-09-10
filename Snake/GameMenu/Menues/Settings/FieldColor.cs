using GameMenu.Menues.Interfaces;
using GameMenu.Repository;
using GameMenu.Repository.Interfaces;
using GameMenu.Utilities;

namespace GameMenu.Menues.Settings
{
    internal class FieldColor : Menu
    {
        private const int Number = 2;

        public FieldColor(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string GetName()
        {
            return "Field Color";
        }
        public override string Execute(IField field)
        {
            this.namespaces.Add(NameSpacesInfo.FieldColor);
            return this.namespaces.Get();;
        }
    }
}
