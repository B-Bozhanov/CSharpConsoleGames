namespace Snake.Models.Menu
{
    using System.Collections.Generic;

    using Interfaces;

    public interface IMenuCreator
    {
        ICollection<IMenu> GetMenues();
    }
}
