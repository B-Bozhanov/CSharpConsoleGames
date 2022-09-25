namespace UserDatabase
{
    using System;
    using Interfaces;
    using Newtonsoft.Json;
    using static Constants.GlobalConstants;

    public partial class UserDatabase : IDatabase
    {
        private IDictionary<string, IAccount> usersDatabase;
        private IAccount currentLogedUser;
        private readonly TimeSpan removeUnUsedAccaundInDays;
        private JsonSerializerSettings jsonSerializerSettings;
        private Thread autoSaveDatabase;
        private int wrongPassCount = WrongPassAttemps;

        public UserDatabase()
        {
            this.usersDatabase = new Dictionary<string, IAccount>();
            this.removeUnUsedAccaundInDays = TimeSpan.FromDays(RemoveUnUsedAccaundInDays);
            this.autoSaveDatabase = new Thread(this.AutoSave);
            this.jsonSerializerSettings = new JsonSerializerSettings
            {
                Converters = { new AbstractConverter<Account, IAccount>() }
            };

            this.autoSaveDatabase.Start();
            //this.autoSaveDatabase.IsBackground = true;
        }


        public int RemaningBlockTime { get; private set; }

        public void AddAccount(string username, string password)
        {
            IAccount account = new Account(username, password);
            account.CreatedTime = DateTime.Now;
            account.LastLoggedInTime = DateTime.Now;

            if (this.usersDatabase.ContainsKey(account.Username))
            {
                throw new ArgumentException("The username exist, try again!");
            }
            this.usersDatabase.Add(account.Username, account);
            this.currentLogedUser = account;
        }

        public IAccount GetAccount(string username, string password)  // TODO : Fix wrongPassCount
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
                if (this.wrongPassCount <= 0)
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

                this.RemoveAccount(Guest);
                this.AutoRemoveUnusedAccaunds();
            }
        }

        public void BlockAccount(IAccount user)
        {
            user.IsBlocked = true;
            user.LastBlockedTime = DateTime.Now;
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

        private void Synchronizeing(object obj, string path)
        {
            string text = JsonConvert
                  .SerializeObject(obj, Formatting.Indented, this.jsonSerializerSettings);

            File.WriteAllText(path, text);
        }

        private void AutoSave()
        {
            int secconds = AutoSaveDatabseIntervalInSecconds * 1000;
            // TODO: Stop this while loop.
            while (true)
            {
                this.Synchronizeing(this.usersDatabase, DefaultFilePath);
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
