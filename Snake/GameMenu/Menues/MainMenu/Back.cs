﻿using GameMenu.Menues.Interfaces;
using GameMenu.Repository.Interfaces;

namespace GameMenu.Menues.MainMenu
{
    internal class Back : Menu
    {
        private const int Number = 3;

        public Back(int row, int col, IRepository<string> namespaces) 
            : base(Number, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field)
        {
            return this.BackCommand();
        }
    }
}
