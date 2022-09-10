namespace UserDatabase.Interfaces
{
    public interface IUserDatabase
    {
        public void Add(IUser user);
        public IUser Get(string user);
    }
}
