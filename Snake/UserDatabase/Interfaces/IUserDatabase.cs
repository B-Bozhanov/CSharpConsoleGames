namespace UserDatabase.Interfaces
{
    public interface IUserDatabase
    {
        public int RemaningBlockTime { get;}

        public void Add(IAccount user);

        public IAccount Get(string user);

        public void SaveDatabase();

        public void LoadDatabase();

        public void BlockAccount(IAccount user);

        public void AutoRemoveUnusedAccaunds();

        public void StartAutoSave();

       // public void CheckForBlockedUsers();
    }
}
