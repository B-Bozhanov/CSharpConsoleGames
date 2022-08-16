namespace GameMenu.Models.Menuses.Settings
{
    internal class ScreenSize : Menu
    {
        private const int Number = 1;
        private const string SizeSubFolder = "GameMenu.Models.Menuses.Settings.SizeSubFolder";
        public ScreenSize(int row, int col)
            : base(Number, row, col)
        {
        }

        public override string GetName()
        {
            return "Screen Size";
        }
        public override string Execute()
        {
            return SizeSubFolder;
        }
    }
}

