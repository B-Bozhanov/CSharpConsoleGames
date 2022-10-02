namespace GameMenu.Core.Interfaces
{
    using GameMenu.Utilities;

    public interface ICursor
    {
        public Coordinates Move(ICollection<Coordinates> coords, Coordinates coordinates);
    }
}
