namespace UsersDatabse.Interfaces
{
    public interface IUserDatabase
    {
        public void Add(IUser user);
        public IUser GetUser(IUser user);
    }
}
