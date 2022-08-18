﻿using GameMenu.Models.Menuses.Settings.Interfaces;

namespace GameMenu.Models.Menuses.Settings.ColorSubFolder
{
    internal class Yellow : Menu, IColor
    {
        private const int Number = 3;
        private const ConsoleColor FieldColor = ConsoleColor.Yellow;
        private const ConsoleColor TextColor = ConsoleColor.Black;
        public Yellow(int row, int col) 
            : base(Number, row, col)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override Type Execute()
        {
            ConsoleField.SetBackgroundColor(FieldColor);
            ConsoleField.SetTextColor(TextColor);
            return base.BackCommand();
        }
    }
}
