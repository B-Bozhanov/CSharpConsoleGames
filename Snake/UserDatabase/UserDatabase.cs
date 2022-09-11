namespace UserDatabase
{
    using global::UserDatabase.Interfaces;
    using System.Text;

    public class UserDatabase : IUserDatabase
    {
        private IDictionary<string, IUser> usersDatabase;

        public UserDatabase()
        {
            this.usersDatabase = new Dictionary<string, IUser>();
        }


        public void Add(IUser user)
        {
            if (this.usersDatabase.ContainsKey(user.Username))
            {
                throw new ArgumentException("The username exist, try again!");
            }
            this.usersDatabase.Add(user.Username, user);
        }

        public IUser Get(string user)
        {
            if (!this.usersDatabase.ContainsKey(user))
            {
                throw new ArgumentException("The username does not exist, try again!");
            }

            return this.usersDatabase[user];
        }

        public void SaveDatabase()
        {
            var users = new StringBuilder();
            foreach (var user in this.usersDatabase.Values)
            {
                users.AppendLine($"{user.Username}, {user.Password}, {user.Score}");
            }
            File.WriteAllText("Users.txt", users.ToString().Trim());
        }

        public void LoadDatabase()
        {
            string database = File.ReadAllText("Users.txt");

            if (!String.IsNullOrWhiteSpace(database))
            {
                string[] users = database.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                foreach (var user in users)
                {
                    string[] userAtributes = user.Split(", ");
                    string username = userAtributes[0];
                    string password = userAtributes[1];
                    int score = int.Parse(userAtributes[2]);

                    this.usersDatabase.Add(username, new User(username, password, score));
                }
            }
        }

        public void RemoveAccount(string username)
        {
            this.usersDatabase.Remove(username);
        }
    }
}
