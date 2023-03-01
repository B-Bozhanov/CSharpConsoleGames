namespace Snake.Models.Menu.Interfaces
{
    using Snake.Common;
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.IO.Interfaces;

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
