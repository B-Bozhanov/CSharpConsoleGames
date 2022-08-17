using GameMenu.Models.Interfaces;
using Snake.Utilities.Interfaces;

namespace GameMenu.Core.Interfaces
{
    internal interface IInterpretor
    {
        HashSet<IMenu> GetMenues(string namespaces, ICoordinates coordinates);
    }
}
