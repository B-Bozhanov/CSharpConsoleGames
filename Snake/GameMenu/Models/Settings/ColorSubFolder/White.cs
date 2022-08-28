﻿using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.Settings.ColorSubFolder
{
    internal class White : Menu
    {
        private const int Number = 1;
        private const ConsoleColor FieldColor = ConsoleColor.White;
        private const ConsoleColor TextColor = ConsoleColor.Black;

        public White(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute()
        {
            Console.ResetColor();
            ConsoleField.SetBackgroundColor(FieldColor);
            ConsoleField.SetTextColor(TextColor);
            return base.BackCommand();
        }
    }
}