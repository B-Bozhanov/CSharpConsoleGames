namespace UserDatabase.Interfaces
{
    public interface IUserDatabase
    {
        public void Add(IUser user);

        public IUser Get(string user);

        public void SaveDatabase();

        public void LoadDatabase();

        public void RemoveAccount(string username);

        public void BlockAccount(IUser user);

        public void StartAutoSave();
    }
}
