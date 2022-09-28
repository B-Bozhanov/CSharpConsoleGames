namespace GameMenu.Menues.Interfaces
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Utilities;

    public interface IMenu
    {
        int MenuNumber { get; }
        public Coordinates MenuCoordinates { get; }

        string GetName();

        string Execute();

        string Execute(IField field, IWriter writer, IReader reader);
    }
}
