namespace GameMenu.IO.Interfaces
{
    public interface IWriter
    {
        void Write(string message);
        void Write(string message, int X, int Y);
        void Clear();
    }
}
