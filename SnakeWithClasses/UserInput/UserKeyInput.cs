using Snake.UserInput;
using System;
// Delete NameSpace
class UserKeyInput
{
    public  KeyPressed GetInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.RightArrow)
            {
                return KeyPressed.Right;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                return KeyPressed.Left;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                return KeyPressed.Down;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                return KeyPressed.Up;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return KeyPressed.Enter;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                return KeyPressed.Exit;
            }
        }
        return KeyPressed.None;
    }
}

