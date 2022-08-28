using Snake.Utilities;

namespace GameMenu.Models.Interfaces
{
    public interface IMenu
    {
        int MenuNumber { get; }
        public Coordinates MenuCoordinates { get; }
        string GetName();
        string Execute();
    }
}
