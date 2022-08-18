namespace GameMenu.Models
{
    using System.Text;
    using Interfaces;

    internal class ConsoleField : IField
    {
        public ConsoleField()
        {
            WindowResizer(WindowHeight, WindowWidth);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }


        public static int WindowHeight { get; private set; } = Console.LargestWindowHeight / 2;

        public static int WindowWidth { get; private set; } = Console.LargestWindowWidth / 2;

        public static int MenuRow { get; private set; }

        public static int MenuCol { get; private set; }


        public static void WindowResizer(int row, int col)
        {
            WindowHeight = row;
            WindowWidth = col;
            MenuRow = WindowHeight / 2 - 4;
            MenuCol = WindowWidth / 2 - 6;
            SetDefaultSettings();
        }

        public static void SetBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        public static void SetTextColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        public static void ResetColor()
        {
            Console.ResetColor();
        }
        private static void SetDefaultSettings()
        {
            Console.Title = "Snake v2.0";
            Console.CursorVisible = false;
            Console.WindowHeight = WindowHeight;
            Console.WindowWidth = WindowWidth;
            Console.BufferHeight = WindowHeight;
            Console.BufferWidth = WindowWidth;
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowPosition(0, 0);
        }
    }
}
