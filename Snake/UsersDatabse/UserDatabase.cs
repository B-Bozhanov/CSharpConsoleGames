namespace UsersDatabse
{
    using UsersDatabse.Interfaces;

    public class UserDatabase : IUserDatabase
    {
        private readonly Dictionary<string, IUser> userDatabase;

        public UserDatabase()
        {
            this.userDatabase = new Dictionary<string, IUser>();
        }

        public void Add(IUser user)
        {
            if (this.userDatabase.ContainsKey(user.Username))
            {
                throw new ArgumentException("User exist!");
            }
            this.userDatabase.Add(user.Username, user);
        }

        public IUser GetUser(IUser user)
        {
            if (!this.userDatabase.ContainsKey(user.Username))
            {
                throw new ArgumentException("User does not exist!");
            }

            return this.userDatabase[user.Username];
        }
    }
}