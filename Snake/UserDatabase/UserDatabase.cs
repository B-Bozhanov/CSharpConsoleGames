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
        private const string DefaultFilePath = "../../../../UserDatabase/UsersData/UserDatabse.json";

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
                string userDatabaseFile = File.ReadAllText(DefaultFilePath);

                var settings = new JsonSerializerSettings
                {
                    Converters = {
                                   new AbstractConverter<Account, IAccount>()
                                 },
                };

                var currentUserDatabase = JsonConvert.DeserializeObject<Dictionary<string, IAccount>>(userDatabaseFile, settings);
                //if (isBlocked)
                //{
                //    currentUser.IsBlocked = true;
                //}
                //this.usersDatabase.Add(username, currentUser);

                //if (currentUser.IsBlocked)
                //{
                //    this.BlockAccount(currentUser);
                //}
            }

           
            //string json = JsonConvert.SerializeObject(this.usersDatabase, Formatting.Indented, settings);
            // JsonWriter writer;

           // File.WriteAllText("test.json", json);
           
            //var test2 = JsonConvert.DeserializeObject<Dictionary<string, IUser>>(test);


           
            Console.WriteLine();
        }

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
