using GameMenu.Models.Menuses.Settings.Interfaces;

namespace GameMenu.Models.Menuses.Settings.ColorSubFolder
{
    internal class Back : Menu, IColor
    {
        private const int Number = 4;
        public Back(int row, int col) 
            : base(Number, row, col)
        {
        }
    }
}
