namespace GameMenu.IO
{
    using GameMenu.Models.Interfaces;
    using Interfaces;
    using System.Collections;
    using System.Collections.Generic;

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
            Console.Write(text);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Write(HashSet<IMenu> menues)
        {
            foreach (var menu in menues)
            {
                string message = menu.GetName();
                this.Write(message, menu.MenuCoordinates.Row, menu.MenuCoordinates.Col);
            }
        }
    }
}
