namespace GameMenu.IO.Interfaces
{
    using GameMenu.Menues.Interfaces;

    public interface IWriter
    {
        void Write(string message);

        void WriteLine(string message);

        void Write(string text, int consoleRow, int consoleCol);

        void Write(HashSet<IMenu> menues);

        void Clear();
    }
}
