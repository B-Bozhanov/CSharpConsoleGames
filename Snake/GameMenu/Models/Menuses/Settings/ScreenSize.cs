using GameMenu.Models.Menuses.Settings.Interfaces;

namespace GameMenu.Models.Menuses.Settings
{
    internal class ScreenSize : Menu, ISettings
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
        public override Type Execute()
        {
            return typeof(ISize);
        }
    }
}

