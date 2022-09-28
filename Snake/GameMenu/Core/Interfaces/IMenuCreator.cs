namespace GameMenu.Core.Interfaces
{
    using GameMenu.Menues.Interfaces;
    using GameMenu.Utilities;


    public interface IMenuCreator
    {
        ICollection<IMenu> GetMenues(Coordinates coordinates);
    }
}
