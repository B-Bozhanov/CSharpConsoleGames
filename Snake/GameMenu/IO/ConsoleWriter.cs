namespace GameMenu.IO
{
    using Interfaces;

    internal class ConsoleWriter : IWriter
    {
        private const ConsoleColor DefaultColor = ConsoleColor.Black;
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string text, int consoleRow, int consoleCol)
        {
            Console.SetCursorPosition(consoleCol, consoleRow);
            Console.WriteLine(text);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
