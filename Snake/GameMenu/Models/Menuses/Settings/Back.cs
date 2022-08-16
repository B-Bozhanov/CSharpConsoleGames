namespace GameMenu.Models.Menuses.Settings
{
    internal class Back : Menu
    {
        private const int Number = 3;

        public Back(int row, int col)
            : base(Number, row, col)
        {

        }

        public override string Execute()
        {
            return base.BackCommand();
        }
    }
}
