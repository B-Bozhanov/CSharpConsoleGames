namespace UserDatabase
{
    using Interfaces;
    using System.Text;

    public class UserDatabase : IUserDatabase
    {
        private const int AccauntBlockTime = 5 * 60;
        private Thread blockAccount;
        private readonly IDictionary<string, IUser> usersDatabase;

        public UserDatabase()
        {
            this.usersDatabase = new Dictionary<string, IUser>();
        }


        public int RemaningBlockTime { get; private set; }

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
                users.AppendLine($"{user.Username}, {user.Password}, {user.Score}, " +
                                 $"{user.IsBlocked.ToString()}, {user.BlockedTimeCount.ToString()}, {user.LastBlockedTime}");
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
                    string isBlocked = userAtributes[3];
                    int blockTimeCount = int.Parse(userAtributes[4]);
                    DateTime lastBlockedTime = DateTime.Parse(userAtributes[5]);

                    IUser currentUser = new User(username, password, score);
                    currentUser.BlockedTimeCount = blockTimeCount;
                    currentUser.LastBlockedTime = lastBlockedTime;
                    var blockedInterval = (DateTime.Now - lastBlockedTime).Duration();

                    if (isBlocked == "True")
                    {
                        currentUser.IsBlocked = true;
                    }
                    this.usersDatabase.Add(username, currentUser);

                    if (currentUser.IsBlocked)
                    {
                        this.BlockAccount(currentUser);
                    }
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
            this.blockAccount = new Thread(Block);
            blockAccount.Start();

            void Block()
            {
                while (user.BlockedTimeCount != AccauntBlockTime)
                {
                    Thread.Sleep(1000);
                    user.BlockedTimeCount++;
                    this.RemaningBlockTime = AccauntBlockTime / 60 - user.BlockedTimeCount / 60;
                }
                user.IsBlocked = false;
                user.BlockedTimeCount = 0;
            }
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
