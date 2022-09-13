namespace UserDatabase
{
    using Interfaces;
    using System.Text;

    public class UserDatabase : IUserDatabase
    {
        private const int BlockTimeInMinutes = 5;

        private Thread blockAccount;
        private readonly TimeSpan accauntBlockTime;
        private readonly IDictionary<string, IUser> usersDatabase;
        private IUser currentLogedUser;

        public UserDatabase()
        {
            this.usersDatabase = new Dictionary<string, IUser>();
            this.accauntBlockTime = TimeSpan.FromMinutes(BlockTimeInMinutes);
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

            this.currentLogedUser = this.usersDatabase[user];
            return currentLogedUser;
        }

        public void SaveDatabase()
        {
            var users = new StringBuilder();
            foreach (var user in this.usersDatabase.Values)
            {
                users.AppendLine($"{user.Username}, {user.Password}, {user.Score}, " +
                                 $"{user.IsBlocked}, {user.LastBlockedTime}, {user.AccountCreatedTime}");
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
                    bool isBlocked = bool.Parse(userAtributes[3]);
                    DateTime lastBlockedTime = DateTime.Parse(userAtributes[4]);

                    IUser currentUser = new User(username, password, score);
                    currentUser.LastBlockedTime = lastBlockedTime;
                    var blockedInterval = (DateTime.Now - lastBlockedTime).Duration();

                    if (isBlocked)
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
                TimeSpan blockDurationLeft = DateTime.Now - user.LastBlockedTime;

                while (blockDurationLeft < this.accauntBlockTime)
                {
                    this.RemaningBlockTime = (int)(this.accauntBlockTime - blockDurationLeft).TotalMinutes;
                    blockDurationLeft = DateTime.Now - user.LastBlockedTime;
                }
                user.IsBlocked = false;
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
