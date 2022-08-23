﻿using GameMenu.Models.Interfaces;
using GameMenu.Repository.Interfaces;
using Snake.Utilities.Interfaces;

namespace GameMenu.Core.Interfaces
{
    internal interface IInterpretor<T1, T2>
    {
        HashSet<IMenu> GetMenues(IRepository<T1> repository, T2 coordinates);
    }
}
