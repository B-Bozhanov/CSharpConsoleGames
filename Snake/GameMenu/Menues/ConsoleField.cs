namespace GameMenu.Menues
{
    using System.Text;
    using Interfaces;

    public class ConsoleField : IField
    {
        public ConsoleField()
        {
            WindowResizer(WindowHeight, WindowWidth);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }


        public int WindowHeight { get; private set; } = Console.LargestWindowHeight / 2;

        public int WindowWidth { get; private set; } = Console.LargestWindowWidth / 2;

        public int MenuRow { get; private set; }

        public int MenuCol { get; private set; }


        public void WindowResizer(int row, int col)
        {
            WindowHeight = row;
            WindowWidth = col;
            MenuRow = WindowHeight / 2 - 4; // TODO: Save magig numbers in const.
            MenuCol = WindowWidth / 2 - 6;
            SetDefaultSettings();
        }

        public void SetBackgroundColor(Color color)
        {
            var backGroundColor = this.GetColor(color);
            Console.BackgroundColor = backGroundColor;
        }

        public void SetTextColor(Color color)
        {
            var textColor = this.GetColor(color);
            Console.ForegroundColor = textColor;
        }
        public void ResetColor()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private ConsoleColor GetColor(Color color)
        {
            switch (color)
            {
                case Color.White:
                    return ConsoleColor.White;
                case Color.Black:
                    return ConsoleColor.Black;
                case Color.Red:
                    return ConsoleColor.Red;
                case Color.Green:
                    return ConsoleColor.Green;
                case Color.Blue:
                    return ConsoleColor.Blue;
                case Color.Yellow:
                    return ConsoleColor.Yellow;
                default:
                    break;
            }
            return default;
        }
        private void SetDefaultSettings()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.Title = "Snake v2.0";
                Console.CursorVisible = false;
                Console.WindowHeight = WindowHeight!;
                Console.WindowWidth = WindowWidth;
                Console.BufferHeight = WindowHeight;
                Console.BufferWidth = WindowWidth;
                Console.OutputEncoding = Encoding.UTF8;
                Console.SetWindowPosition(0, 0);
            }
        }
    }
}
