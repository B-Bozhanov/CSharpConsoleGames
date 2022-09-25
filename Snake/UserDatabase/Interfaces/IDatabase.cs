namespace UserDatabase.Interfaces
{
    public interface IDatabase
    {
        public int RemaningBlockTime { get;}

        public void AddAccount(string username, string password);

        public IAccount GetAccount(string username, string password);

        public void LoadDatabase();

        public void BlockAccount(IAccount user);
    }
}
