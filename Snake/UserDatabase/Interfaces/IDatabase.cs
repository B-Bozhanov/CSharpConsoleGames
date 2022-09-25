namespace UserDatabase.Interfaces
{
    public interface IDatabase
    {
        public int RemaningBlockTime { get;}

        public void AddAccount(string username, string password);

        public IAccount GetAccount(string username, string password);

        public void LoadDatabase();

        public void SaveDatabase();

        public void Update();

        public void BlockAccount(IAccount user);
    }
}
