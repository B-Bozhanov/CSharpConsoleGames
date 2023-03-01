namespace Snake.Models.Menu.Core.Interfaces
{
    using Snake.Common;
    using Snake.Models.Menu.Interfaces;

    public interface ICursor
    {
        public Coordinates Move(ICollection<IMenu> menues, Coordinates coordinates);
    }
}
