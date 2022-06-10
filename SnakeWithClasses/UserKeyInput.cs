using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class UserKeyInput
    {
        private static string keyPressed;

        public static string KeyPressed() // May be return Int
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow)
                {
                    keyPressed = "Right";
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    keyPressed = "Left";
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    keyPressed = "Down";
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    keyPressed = "Up";
                }
            }
            return keyPressed;
        }
    }
}
