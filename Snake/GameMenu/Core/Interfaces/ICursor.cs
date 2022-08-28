namespace GameMenu.Core.Interfaces
{
    using GameMenu.Models.Interfaces;
    using Snake.Utilities.Interfaces;

    internal interface ICursor
    {
        ICoordinates Move(HashSet<IMenu> menues, ICoordinates coordinates);
    }
}
