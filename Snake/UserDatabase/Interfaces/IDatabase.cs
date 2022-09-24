namespace UserDatabase.Interfaces
{
    public interface IDatabase
    {
        public int RemaningBlockTime { get;}

        public bool IsGameOver { get; set; }

        public void AddAccount(IAccount user);

        public IAccount Get(string username);

        public void LoadDatabase();

        public void SaveDatabase();

        public void Update();

        public void BlockAccount(IAccount user);
    }
}
