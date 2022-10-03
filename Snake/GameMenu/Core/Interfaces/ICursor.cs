namespace GameMenu.Core.Interfaces
{
    using GameMenu.Menues.Interfaces;
    using GameMenu.Utilities;

    public interface ICursor
    {
        public Coordinates Move(ICollection<IMenu> menues, Coordinates coordinates);
    }
}
