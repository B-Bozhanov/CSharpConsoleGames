namespace Snake.Models.Menu.Core.Interfaces
{
    using System.Collections.Generic;

    using Snake.Common;
    using Snake.Models.Menu.Interfaces;

    public interface ICursor
    {
        public Coordinates Move(ICollection<IMenu> menues, Coordinates coordinates);
    }
}
