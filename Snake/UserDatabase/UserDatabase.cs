namespace UserDatabase
{
    using Interfaces;
    using Nancy.Json;
    using Newtonsoft.Json;
    using System.Text;

    public partial class UserDatabase : IUserDatabase
    {
        private const int BlockTimeInMinutes = 5;
        private const int RemoveUnUsedAccaundInDays = 30;
        private const string Guest = "Guest";
        private const string DefaultFilePath = "../../../../UserDatabase/UsersData/Users.txt";

        private Thread blockAccount;
        private readonly TimeSpan accauntBlockTime;
        private readonly TimeSpan removeUnUsedAccaundInDays;
        private readonly IDictionary<string, IAccount> usersDatabase;
        private IAccount currentLogedUser;

        public UserDatabase()
        {
            this.usersDatabase = new Dictionary<string, IAccount>();
            this.accauntBlockTime = TimeSpan.FromMinutes(BlockTimeInMinutes);
            this.removeUnUsedAccaundInDays = TimeSpan.FromDays(RemoveUnUsedAccaundInDays);

            this.RemoveAccount(Guest);
        }


        public int RemaningBlockTime { get; private set; }


        public void Add(IAccount user)
        {
            if (this.usersDatabase.ContainsKey(user.Username))
            {
                throw new ArgumentException("The username exist, try again!");
            }
            this.usersDatabase.Add(user.Username, user);
        }

        public IAccount Get(string user)
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
                                 $"{user.IsBlocked}, {user.LastBlockedTime}, {user.AccountCreatedTime}, " +
                                 $"{user.LastLoggedInTime}");
            }
            string database = File.ReadAllText(DefaultFilePath);

            if (users.ToString() != database)
            {
                File.WriteAllText(DefaultFilePath, users.ToString().Trim());
            }
        }

        public void LoadDatabase()
        {
            string database = null;

            try
            {
                database = File.ReadAllText(DefaultFilePath);
            }
            catch 
            {
                File.Create(DefaultFilePath);
            }

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
                    DateTime accountCreatedTime = DateTime.Parse(userAtributes[5]);
                    DateTime lastloggedin = DateTime.Parse(userAtributes[6]);

                    IAccount currentUser = new Account(username, password, score);
                    currentUser.LastBlockedTime = lastBlockedTime;
                    currentUser.AccountCreatedTime = accountCreatedTime;
                    currentUser.LastLoggedInTime = lastloggedin;

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

            var settings = new JsonSerializerSettings
            {
                Converters = {
                               new AbstractConverter<Account, IAccount>()
                             },
            };
            string json = JsonConvert.SerializeObject(this.usersDatabase, Formatting.Indented, settings);
            // JsonWriter writer;

            File.WriteAllText("test.json", json);
            string test = File.ReadAllText("test.json");
            //var test2 = JsonConvert.DeserializeObject<Dictionary<string, IUser>>(test);


            var test3 = JsonConvert.DeserializeObject<Dictionary<string, IAccount>>(test, settings);
            Console.WriteLine();
        }

        private void RemoveAccount(string username)
        {
            this.usersDatabase.Remove(username);
        }

        public void AutoRemoveUnusedAccaunds()
        {
            foreach (var user in this.usersDatabase.Values)
            {
                TimeSpan notLoggedInAccauntTime = DateTime.Now - user.LastLoggedInTime;
                if (notLoggedInAccauntTime > this.removeUnUsedAccaundInDays)
                {
                    this.RemoveAccount(user.Username);
                }
            }
        }

        public void BlockAccount(IAccount user)
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
