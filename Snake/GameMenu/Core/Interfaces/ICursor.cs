namespace GameMenu.Core.Interfaces
{
    internal interface ICursor<T1, T2>
    {
        T2 Move(T1 menues, T2 coordinates);
    }
}
