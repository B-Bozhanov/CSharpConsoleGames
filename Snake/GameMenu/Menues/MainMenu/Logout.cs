using GameMenu.IO;
using GameMenu.IO.Interfaces;
using GameMenu.Menues.Interfaces;
using GameMenu.Repository.Interfaces;

namespace GameMenu.Menues.MainMenu
{
    internal class Logout : Menu
    {
        private const int SequenceNumber = 3;

        public Logout(int row, int col, IRepository<string> namespaces) 
            : base(SequenceNumber, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            writer.Clear();
            writer.Write("Successful logout!", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            Thread.Sleep(2000);
            return this.BackCommand();
        }
    }
}
