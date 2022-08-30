namespace GameMenu.IO
{
    using GameMenu.IO.Interfaces;

    internal class ConsoleReader : IReader
    {
        public string ReadeLine()
        {
            return Console.ReadLine();
        }
    }
}
