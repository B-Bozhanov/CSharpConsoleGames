namespace GameMenu.Models.Menuses.Settings
{
    using Interfaces;

    internal class FieldColor : Menu
    {
        private const int Number = 2;
        private const string ColorSubfolder = "GameMenu.Models.Menuses.Settings.ColorSubFolder";

        public FieldColor(int row, int col)
            : base(Number, row, col)
        {
        }

        public override string GetName()
        {
            return "Field Color";
        }
        public override string Execute()
        {
            NameSpaces.Push(ColorSubfolder);
            return NameSpaces.Peek();;
        }
    }
}
