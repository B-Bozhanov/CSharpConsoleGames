namespace GameMenu.IO
{
    using Interfaces;
    using GameMenu.Menues.Interfaces;
    using System.Collections.Generic;

    public class ConsoleWriter : IWriter
    {
        private const ConsoleColor DefaultColor = ConsoleColor.Black;


        public void Write(string message)
        {
            Console.Write(message);
        }

        public void Write(string text, int consoleRow, int consoleCol)
        {
            Console.SetCursorPosition(consoleCol, consoleRow);
            Console.Write(text);
        }

        public void Write(HashSet<IMenu> menues)
        {
            foreach (var menu in menues)
            {
                string message = menu.GetName();
                this.Write(message, menu.MenuCoordinates.Row, menu.MenuCoordinates.Col);
            }
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
