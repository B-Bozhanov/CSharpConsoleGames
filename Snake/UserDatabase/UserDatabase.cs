namespace UserDatabase
{
    using Interfaces;
    using Nancy.Json;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Text.Json.Nodes;

    public partial class UserDatabase : IDatabase
    {
        private const int BlockTimeInMinutes = 15;
        private const int RemoveUnUsedAccaundInDays = 30;
        private const int AutoSaveIntervalnSecconds = 1;
        private const string Guest = "Guest";
        private const string DefaultFilePath = "../../../../UserDatabase/UsersData/UserDatabse.json";
        private const string DefaultTempFilePath = "../../../../UserDatabase/UsersData/CurrentUserData.json";

        private IDictionary<string, IAccount> usersDatabase;
        private IAccount currentLogedUser;
        private readonly TimeSpan accauntBlockTime;
        private readonly TimeSpan removeUnUsedAccaundInDays;
        private JsonSerializerSettings jsonSerializerSettings;

        public UserDatabase()
        {
            this.usersDatabase = new Dictionary<string, IAccount>();
            this.accauntBlockTime = TimeSpan.FromMinutes(BlockTimeInMinutes);
            this.removeUnUsedAccaundInDays = TimeSpan.FromDays(RemoveUnUsedAccaundInDays);
            this.jsonSerializerSettings = new JsonSerializerSettings
            {
                Converters = { new AbstractConverter<Account, IAccount>() }
            };
        }


        public int RemaningBlockTime { get; private set; }


        public void AddAccount(IAccount user)
        {
            if (this.usersDatabase.ContainsKey(user.Username))
            {
                throw new ArgumentException("The username exist, try again!");
            }
            this.usersDatabase.Add(user.Username, user);

            this.Synchronizeing(this.usersDatabase, DefaultFilePath);
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

        public void LoadDatabase()
        {
            if (!File.Exists(DefaultFilePath))
            {
                File.Create(DefaultFilePath).Close();
            }

            string userDatabaseFile = File.ReadAllText(DefaultFilePath);

            if (!String.IsNullOrWhiteSpace(userDatabaseFile))
            {
                this.usersDatabase = JsonConvert
                    .DeserializeObject<Dictionary<string, IAccount>>(userDatabaseFile, this.jsonSerializerSettings);
            }
        }

        public void Synchronizeing(object obj, string path)
        {
            string text = JsonConvert
                  .SerializeObject(obj, Formatting.Indented, this.jsonSerializerSettings);

            File.WriteAllText(path, text);
        }

        public void Update()
        {
            string userDatabaseFile = File.ReadAllText(DefaultTempFilePath);
            IAccount account = JsonConvert.DeserializeObject<IAccount>(userDatabaseFile, this.jsonSerializerSettings);

            var blockedAccounts = this.usersDatabase.Values.Where(a => a.IsBlocked);

            foreach (var blockedAccount in blockedAccounts)
            {
                this.BlockAccount(blockedAccount);
            }

            if (account != null && this.usersDatabase.ContainsKey(account.Username))
            {
                this.usersDatabase[account.Username] = account;
                this.RemoveAccount(Guest);
                this.Synchronizeing(this.usersDatabase, DefaultFilePath);
            }
            this.AutoRemoveUnusedAccaunds();
            var autoSaveDatabase = new Thread(this.AutoSaveDatabase);
            autoSaveDatabase.Start();
        }

        public void BlockAccount(IAccount user)
        {
            user.IsBlocked = true;
            var blockAccount = new Thread(Block);
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

        private void AutoSaveDatabase()
        {
            var secconds = AutoSaveIntervalnSecconds * 1000;
            while (true)
            {
                if (this.currentLogedUser != null)
                {
                    this.Synchronizeing(this.currentLogedUser, DefaultTempFilePath);
                    Thread.Sleep(secconds);
                }
            }
        }

        private void RemoveAccount(string username)
        {
            this.usersDatabase.Remove(username);
        }

        private void AutoRemoveUnusedAccaunds()
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
    }
}
