namespace GameMenu.Models.Menuses.Settings.ColorSubFolder
{
    internal class Black : Menu
    {
        private const int Number = 2;

        public Black(int row, int col)
            : base(Number, row, col)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute()
        {
            Console.ResetColor();
            return base.BackCommand();
        }
    }
}
