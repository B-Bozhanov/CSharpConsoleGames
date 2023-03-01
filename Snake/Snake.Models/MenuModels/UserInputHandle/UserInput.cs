namespace Snake.Models.Menu.UserInputHandle
{
    using System;

    using Snake.Models.Menu.UserInputHandle.Interfaces;

    public class UserInput : IUserInput
    {
        public KeyPressed GetInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow: return KeyPressed.Right;
                    case ConsoleKey.LeftArrow: return KeyPressed.Left;
                    case ConsoleKey.UpArrow: return KeyPressed.Up;
                    case ConsoleKey.DownArrow: return KeyPressed.Down;
                    case ConsoleKey.W: return KeyPressed.Up;
                    case ConsoleKey.A: return KeyPressed.Left;
                    case ConsoleKey.S: return KeyPressed.Down;
                    case ConsoleKey.D: return KeyPressed.Right;
                    case ConsoleKey.Enter: return KeyPressed.Enter;
                    case ConsoleKey.Y: return KeyPressed.Yes;
                    case ConsoleKey.N: return KeyPressed.No;
                        // case ConsoleKey.Escape: return KeyPressed.Exit;
                }
            }
            return KeyPressed.None;
        }
    }
}
