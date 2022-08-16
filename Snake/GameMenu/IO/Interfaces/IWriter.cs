using GameMenu.Models.Interfaces;
using System.Collections;

namespace GameMenu.IO.Interfaces
{
    public interface IWriter
    {
        void Write(string message);
        void Write(string message, int X, int Y);
        void Write(HashSet<IMenu> menues);
        void Clear();
    }
}
