using GameMenu.IO;
using GameMenu.IO.Interfaces;
using GameMenu.Menues.Interfaces;
using GameMenu.Repository.Interfaces;

namespace GameMenu.Menues.MainMenu
{
    internal class Logout : Menu
    {
        private const int SequenceNumber = 3;
        private IWriter writer;
        private IReader reader;

        public Logout(int row, int col, IRepository<string> namespaces) 
            : base(SequenceNumber, row, col, namespaces)
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field)
        {
            this.writer.Clear();
            this.writer.Write("Successful logout!", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            Thread.Sleep(2000);
            return this.BackCommand();
        }
    }
}
