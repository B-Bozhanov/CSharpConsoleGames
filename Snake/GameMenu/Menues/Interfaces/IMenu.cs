namespace GameMenu.Menues.Interfaces
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Utilities;

    public interface IMenu
    {
        int ID { get; }

        public Coordinates MenuCoordinates { get; }

        string GetName();

        string Execute();

        string Execute(IField field, IWriter writer);

        string Execute(IWriter writer);

        string Execute(IWriter writer, IReader reader);

        string Execute(IField field);

        string Execute(IField field, IWriter writer, IReader reader);
    }
}
