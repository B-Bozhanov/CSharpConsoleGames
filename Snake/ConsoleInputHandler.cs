namespace Snake
{
    public class ConsoleInputHandler : IInputHandler
    {
        public KeyboardKey GetPressedKeyboardKey(KeyboardKey currentPressedKey)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                {
                    return KeyboardKey.Right;
                }
                if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                {
                    return KeyboardKey.Left;
                }
                if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                {
                    return KeyboardKey.Down;
                }
                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                {
                    return KeyboardKey.Up;
                }
            }

            return currentPressedKey;
        }
    }
}
