namespace UserDatabase.Interfaces
{
    public interface IUserDatabase
    {
        public int RemaningBlockTime { get;}

        public void Add(IUser user);

        public IUser Get(string user);

        public void SaveDatabase();

        public void LoadDatabase();

        public void BlockAccount(IUser user);

        public void AutoRemoveUnusedAccaunds();

        public void StartAutoSave();

       // public void CheckForBlockedUsers();
    }
}
