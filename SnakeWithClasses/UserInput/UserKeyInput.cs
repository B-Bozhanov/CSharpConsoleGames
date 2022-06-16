using System;
namespace Snake
{
    public class UserKeyInput
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
                    case ConsoleKey.Enter: return KeyPressed.Enter;
                   // case ConsoleKey.Escape: return KeyPressed.Exit;
                }
            }
            return KeyPressed.None;
        }
        public enum KeyPressed
        {
            None,
            Left,
            Right,
            Up,
            Down,
            Enter,
            Back,
            Exit
        }
    }
}




