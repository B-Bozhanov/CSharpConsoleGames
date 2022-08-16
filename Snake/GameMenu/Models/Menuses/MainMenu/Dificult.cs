namespace GameMenu.Models.Menuses.MainMenu
{
    internal class Dificult : Menu
    {
        private const int Number = 3;
        public Dificult(int row, int col)
            : base(Number, row, col)
        {
        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
