namespace GameMenu.Menues.Interfaces
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;

    using Snake.Common;

    public interface IMenu
    {
        int ID { get; }

        public Coordinates MenuCoordinates { get; }

        string GetName();

        string Execute();

        string Execute(IField field, IRenderer renderer);

        string Execute(IRenderer renderer);

        string Execute(IField field);
    }
}
