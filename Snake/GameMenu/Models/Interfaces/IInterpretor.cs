namespace GameMenu.Models.Interfaces
{
    internal interface IInterpretor
    {
        HashSet<IMenu> GetMenues(string namespaces, int row, int col);
    }
}
