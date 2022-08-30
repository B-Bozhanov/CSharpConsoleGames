namespace GameMenu.Models.Interfaces
{
    using Snake.Utilities;
    using UserDatabase.Interfaces;

    public interface IMenu
    {
        int MenuNumber { get; }
        public Coordinates MenuCoordinates { get; }
        string GetName();
        string Execute();
        IUser Execute(IUser user);
    }
}
