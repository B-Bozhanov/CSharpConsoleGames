namespace IO.Console
{
    using System;
    using GameMenu.IO.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadAllText()
        {
            throw new NotImplementedException();
        }

        public string ReadLine()
        {
            return Console.ReadLine()!;
        }
    }
}
