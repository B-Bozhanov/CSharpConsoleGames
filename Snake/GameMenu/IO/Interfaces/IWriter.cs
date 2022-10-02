using GameMenu.Menues.Interfaces;

namespace GameMenu.IO.Interfaces
{
    public interface IWriter
    {
        void Write(string message);

        void WriteLine(string message);

        void Write(string text, int consoleRow, int consoleCol);

        void Write(ICollection<IMenu> menues);

        public string PasswordMask();

        void Clear();
    }
}
