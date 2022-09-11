namespace IO.Console
{
    using System;
    using GameMenu.IO.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadeLine()
        {
            return Console.ReadLine()!;
        }
    }
}
