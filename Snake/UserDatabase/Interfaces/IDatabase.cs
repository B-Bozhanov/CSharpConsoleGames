namespace UserDatabase.Interfaces
{
    public interface IDatabase
    {
        public int RemaningBlockTime { get;}

        public void AddAccount(IAccount user);

        public IAccount Get(string username);

        public void LoadDatabase();

        public void SaveAccount(object obj, string path);

        public void Update();

        public void BlockAccount(IAccount user);
    }
}
