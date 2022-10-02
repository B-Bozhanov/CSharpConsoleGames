namespace IO.Console
{
    using System;
    using System.Collections.Generic;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;

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

        public string PasswordMask()
        {
            string password = null!;
            ConsoleKey key;

            while (true)
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Enter)
                {
                    return password;
                }
                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password.Substring(0, password.Length - 1); //password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Write(ICollection<IMenu> menues)
        {
            foreach (var menu  in menues)
            {
                this.Write(menu.GetName(), menu.MenuCoordinates.Row, menu.MenuCoordinates.Col);
            }
        }
    }
}
