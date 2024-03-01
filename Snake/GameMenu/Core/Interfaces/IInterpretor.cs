using GameMenu.IO.Interfaces;
namespace GameMenu.Core.Interfaces
{
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UserDatabase.Interfaces;


    internal interface IInterpretor<T1, T2>
    {
        HashSet<IMenu> GetMenues(IRepository<T1> repository, T2 coordinates, IDatabase users);
    }
}
