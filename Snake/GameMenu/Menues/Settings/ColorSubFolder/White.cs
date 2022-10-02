﻿namespace GameMenu.Menues.Settings.ColorSubFolder
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class White : Menu, IColor
    {
        private const int SequenceNumber = 1;


        public override int ID { get; protected set; }

        public Color FieldColor { get; } = Color.White;

        public Color TextColor { get; } = Color.Black;

        public White(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute(IField field)
        {
            field.ResetColor();
            field.SetBackgroundColor(this.FieldColor);
            field.SetTextColor(this.TextColor);
            base.BackCommand();
            return null;
        }
    }
}
