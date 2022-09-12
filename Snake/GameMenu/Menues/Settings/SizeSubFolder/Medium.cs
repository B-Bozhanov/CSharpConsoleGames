﻿using GameMenu.IO.Interfaces;
using GameMenu.Menues.Interfaces;
using GameMenu.Repository.Interfaces;

namespace GameMenu.Menues.Settings.SizeSubFolder
{
    internal class Medium : Menu
    {
        private const int Number = 2;
        private readonly int ConsoleRows = Console.LargestWindowHeight / 2;
        private readonly int ConsoleCols = Console.LargestWindowWidth / 2;

        public Medium(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            field.WindowResizer(ConsoleRows, ConsoleCols);
            return base.BackCommand();
        }
    }
}
