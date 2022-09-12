namespace GameMenu.Menues.Interfaces
{
    using GameMenu.IO.Interfaces;
    using Snake.Utilities;

    public interface IMenu
    {
        int MenuNumber { get; }
        public Coordinates MenuCoordinates { get; }

        string GetName();

        string Execute();

        string Execute(IField field, IWriter writer, IReader reader);
    }
}
