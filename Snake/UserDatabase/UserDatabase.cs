namespace UserDatabase
{
    using global::UserDatabase.Interfaces;
    using System.Diagnostics;
    using System.Text;
    using static System.Net.Mime.MediaTypeNames;

    public class UserDatabase : IUserDatabase
    {
        private readonly IDictionary<string, IUser> usersDatabase;
        private MyStopwatch sw;

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
                var userBlockTime = sw.ElapsedMilliseconds;
                users.AppendLine($"{user.Username}, {user.Password}, {user.Score}, {userBlockTime.ToString()}");
            }
            string database = File.ReadAllText("Users.txt");

            if (users.ToString() != database)
            {
                File.WriteAllText("Users.txt", users.ToString().Trim());
            }
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

                    IUser currentUser = new User(username, password, score);
                    //currentUser.BlockedTime = double.Parse(userAtributes[3])
                    this.usersDatabase.Add(username, currentUser);
                }
            }
        }

        public void RemoveAccount(string username)
        {
            this.usersDatabase.Remove(username);
        }

        public void BlockAccount(IUser user)
        {
            user.IsBlocked = true;
            var test = TimeSpan.FromSeconds((int)25);
            sw.Start();
        }

        public void StartAutoSave()
        {
            Thread autoSaveDatabase = new Thread(this.AutoSave);
            autoSaveDatabase.Start();
        }

        private void AutoSave()
        {
            while (true)
            {
                this.SaveDatabase();
                Thread.Sleep(1000);
            }
        }
    }
}
