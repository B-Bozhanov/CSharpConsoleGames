namespace SnakeProject.UserInput
{
    using SnakeProject.UserInput.Inerfaces;

    internal class UserInputHandle : IUserInputHandle
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
    }
}
