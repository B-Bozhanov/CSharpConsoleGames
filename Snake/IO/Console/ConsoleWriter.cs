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

        public string PasswordMask(int row, int col)
        {
            string password = null!;

            int count = 0;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        return password;
                    }

                    password += key.KeyChar;
                    this.Write("*", row, col + count);
                    count++;
                }
            }
           // return null;
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
