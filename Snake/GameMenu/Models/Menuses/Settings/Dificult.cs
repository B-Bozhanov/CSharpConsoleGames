using GameMenu.Models.Menuses.Settings.Interfaces;

namespace GameMenu.Models.Menuses.Settings
{
    internal class Dificult : Menu, ISettings
    {
        private const int Number = 3;
        public Dificult(int row, int col)
            : base(Number, row, col)
        {
        }

        public override Type Execute()
        {
            throw new NotImplementedException();
        }
    }
}
