namespace GameMenu.IO.Console
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues;

    using Snake.Models.Menu.Interfaces;

    using System;
    using System.Collections.Generic;

    public class ConsoleRenderer : IRenderer
    {
        public string ReadAllText()
        {
            throw new NotImplementedException();
        }

        public string ReadLine()
        {
            return Console.ReadLine()!;
        }
               
        public void Write(string message)//, Color color)
        {
            Console.Write(message);
        }

        public void Write(string text, int row, int col)//, Color color)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(text);
        }

        public void Write(ICollection<IMenu> menues)
        {
            foreach (var menu in menues)
            {
                this.Write(menu.GetName(), menu.MenuCoordinates.Row, menu.MenuCoordinates.Col);
            }
        }

        //public void Write(ICollection<Coordinates> elements)
        //{
        //    foreach (var element in elements)
        //    {
        //        this.Write(element.Sys)
        //    }
        //}

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
            Console.Clear();
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
    }
}
