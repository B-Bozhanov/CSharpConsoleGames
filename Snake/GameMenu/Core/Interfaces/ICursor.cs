namespace GameMenu.Core.Interfaces
{
    using GameMenu.Menues.Interfaces;

    using Snake.Common;

    public interface ICursor
    {
        public Coordinates Move(ICollection<IMenu> menues, Coordinates coordinates);
    }
}
