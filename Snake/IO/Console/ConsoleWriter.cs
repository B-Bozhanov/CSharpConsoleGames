namespace IO.Console
{
    using System;
    using GameMenu.IO.Interfaces;
    using System.Collections.Generic;
    using System.Collections;

    public class ConsoleWriter : IWriter
    {
        private const ConsoleColor DefaultColor = ConsoleColor.Black;


        public void Write(string message)
        {
            Console.Write(message);
        }

        public void Write(string text, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(text);
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
