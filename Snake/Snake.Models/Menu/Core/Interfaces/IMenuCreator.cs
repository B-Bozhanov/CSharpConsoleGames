﻿namespace Snake.Models.Menu.Core.Interfaces
{
    using Snake.Models.Menu.Interfaces;

    public interface IMenuCreator
    {
        ICollection<IMenu> GetMenues();
    }
}