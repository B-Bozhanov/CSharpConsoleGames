namespace UserDatabase
{
    using global::UserDatabase.Interfaces;

    public class UserDatabase : IUserDatabase
    {
        private readonly Dictionary<string, IUser> users;

        public UserDatabase()
        {
            this.users = new Dictionary<string, IUser>();
        }

        public void Add(IUser user)
        {
            if (this.users.ContainsKey(user.Username))
            {
                throw new ArgumentException("The username exist, try again!");
            }
            this.users.Add(user.Username, user);
        }

        public IUser Get(IUser user)
        {
            if (!this.users.ContainsKey(user.Username))
            {
                throw new ArgumentException("The username does not exist, try again!");
            }

            return this.users[user.Username];
        }
    }
}
