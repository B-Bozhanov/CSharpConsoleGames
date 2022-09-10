using GameMenu.Menues.Interfaces;
using GameMenu.Repository.Interfaces;
using Snake.Utilities.Interfaces;
using UserDatabase.Interfaces;

namespace GameMenu.Core.Interfaces
{
    internal interface IInterpretor<T1, T2>
    {
        HashSet<IMenu> GetMenues(IRepository<T1> repository, T2 coordinates, IUserDatabase users);
    }
}
