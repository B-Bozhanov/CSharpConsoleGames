namespace Snake.Models.Menu.IO.Interfaces
{
    using Snake.Models.Menu.Interfaces;

    public interface IRenderer
    {
        string ReadLine();

        string ReadAllText();

        void Write(string message);

        void WriteLine(string message);

        void Write(string text, int consoleRow, int consoleCol);

        void Write(ICollection<IMenu> menues);

        public string PasswordMask();

        void Clear();
    }
}
