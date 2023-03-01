namespace GameMenu.Core.Interfaces
{
    using GameMenu.Menues.Interfaces;


    public interface IMenuCreator
    {
        ICollection<IMenu> GetMenues();
    }
}
