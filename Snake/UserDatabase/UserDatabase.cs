namespace UserDatabase
{
    using System;
    using Interfaces;
    using Newtonsoft.Json;
    using static Constants.GlobalConstants;

    public partial class UserDatabase : IDatabase
    {
        //private const int BlockTimeInMinutes = 15;
        //private const int RemoveUnUsedAccaundInDays = 30;
        //private const int AutoSaveCurrentAccountIntervalInSecconds = 1;
        //private const int AutoSaveDatabseIntervalInMinutes = 5;
        //private const int WrongPassAttemps = 2;
        //private const string Guest = "Guest";
        //private const string DefaultFilePath = "../../../../UserDatabase/UsersData/UserDatabse.json";
        //private const string DefaultTempFilePath = "../../../../UserDatabase/UsersData/CurrentUserData.json";

        private IDictionary<string, IAccount> usersDatabase;
        private IAccount currentLogedUser;
        private IList<IAccount> blockedAccountsList;
        private readonly TimeSpan removeUnUsedAccaundInDays;
        private DateTime lastDatabaseSaveTime = DateTime.Now;
        private JsonSerializerSettings jsonSerializerSettings;
        private Thread autoSaveDatabase;
        private int wrongPassCount = WrongPassAttemps;

        public UserDatabase()
        {
            this.usersDatabase = new Dictionary<string, IAccount>();
            this.removeUnUsedAccaundInDays = TimeSpan.FromDays(RemoveUnUsedAccaundInDays);
            this.autoSaveDatabase = new Thread(this.AutoSave);
            this.blockedAccountsList = new List<IAccount>();
            this.jsonSerializerSettings = new JsonSerializerSettings
            {
                Converters = { new AbstractConverter<Account, IAccount>() }
            };

            this.autoSaveDatabase.Start();
            //this.autoSaveDatabase.IsBackground = true;
        }


        public int RemaningBlockTime { get; private set; }


        public void AddAccount(IAccount user)
        {
            if (this.usersDatabase.ContainsKey(user.Username))
            {
                throw new ArgumentException("The username exist, try again!");
            }
            this.usersDatabase.Add(user.Username, user);
            this.currentLogedUser = user;
            this.Synchronizeing(this.usersDatabase, DefaultFilePath);
        }

        public IAccount GetAccount(string username, string password)
        {
            if (!this.usersDatabase.ContainsKey(username))
            {
                throw new ArgumentException("The username does not exist, try again!");
            }

            var user = this.usersDatabase[username];
            BlockedAccountValidator(user);

            if (user.IsBlocked)
            {
                throw new ArgumentException($"Account is blocked, try after {this.RemaningBlockTime} minutes!");
            }

            if (user.Password != password)
            {
                this.wrongPassCount--;
                if (this.wrongPassCount == 0)
                {
                    this.BlockAccount(user);
                    throw new ArgumentException($"{this.wrongPassCount} attemps left! Account is blocked for 15 minutes");
                }

                throw new ArgumentException($"Incorect password, try again! {this.wrongPassCount} attemps left!");
            }

            this.currentLogedUser = this.usersDatabase[username];
            this.wrongPassCount = WrongPassAttemps;
            BlockedAccountValidator(user);
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

                foreach (var user in this.usersDatabase.Values)
                {
                    this.BlockedAccountValidator(user);
                }
            }
        }

        public void Update()
        {
            string userDatabaseFile = File.ReadAllText(DefaultTempFilePath);
            IAccount account = JsonConvert.DeserializeObject<IAccount>(userDatabaseFile, this.jsonSerializerSettings);

            this.blockedAccountsList = this.usersDatabase.Values.Where(a => a.IsBlocked).ToList();

            if (account != null && this.usersDatabase.ContainsKey(account.Username))
            {
                this.usersDatabase[account.Username] = account;
                this.RemoveAccount(Guest);
                this.Synchronizeing(this.usersDatabase, DefaultFilePath);
            }
            this.AutoRemoveUnusedAccaunds();

        }

        public void BlockAccount(IAccount user)
        {
            user.IsBlocked = true;
            user.LastBlockedTime = DateTime.Now;
            this.blockedAccountsList.Add(user);
        }

        private void BlockedAccountValidator(IAccount user)
        {
            this.RemaningBlockTime = BlockTimeInMinutes - user.ExpiredBlockTime;
            if (this.RemaningBlockTime <= 0)
            {
                user.IsBlocked = false;
            }
            this.currentLogedUser = user;
            //this.Update();
        }

        public void SaveDatabase()
        {
            this.Synchronizeing(this.usersDatabase, DefaultFilePath);
        }

        private void Synchronizeing(object obj, string path)
        {
            string text = JsonConvert
                  .SerializeObject(obj, Formatting.Indented, this.jsonSerializerSettings);

            File.WriteAllText(path, text);
        }

        private void AutoSave()
        {
            var secconds = AutoSaveCurrentAccountIntervalInSecconds * 1000;
            // TODO: Stop this while loop.
            while (true)
            {
                var ExpiredDatabaseSaveTime = (int)(DateTime.Now - this.lastDatabaseSaveTime).TotalMinutes;

                if (this.currentLogedUser != null)
                {
                    this.Synchronizeing(this.currentLogedUser, DefaultTempFilePath);
                }
                if (ExpiredDatabaseSaveTime >= AutoSaveDatabseIntervalInMinutes)
                {
                    this.Synchronizeing(this.usersDatabase, DefaultFilePath);
                    this.lastDatabaseSaveTime = DateTime.Now;
                }
                Thread.Sleep(secconds);
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
