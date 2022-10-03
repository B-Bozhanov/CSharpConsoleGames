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
        private int wrongPassCount = WrongPassAttemps;

        public UserDatabase()
        {
            this.usersDatabase = new Dictionary<string, IAccount>();
            this.removeUnUsedAccaundInDays = TimeSpan.FromDays(RemoveUnUsedAccaundInDays);
            this.jsonSerializerSettings = new JsonSerializerSettings
            {
                Converters = { new AbstractConverter<Account, IAccount>() }
            };
        }

        public int RemaningBlockTime { get; private set; }


        public void AddAccount(string username, string password)
        {
            IAccount account = new Account(username, password);

            if (this.usersDatabase.ContainsKey(account.Username))
            {
                throw new ArgumentException("The username exist, try again!");
            }

            account.CreatedTime = DateTime.Now;
            account.LastLoggedInTime = DateTime.Now;
            this.usersDatabase.Add(username, account);
            this.currentLogedUser = account;
        }

        public IAccount GetAccount(string username, string password)  // TODO : when new user try to login, he is begin with the wrong attemps from other user.
        {
            if (!this.usersDatabase.ContainsKey(username))
            {
                throw new ArgumentException("The username does not exist, try again!");
            }

            if (this.wrongPassCount == 0) this.wrongPassCount = WrongPassAttemps;

            var account = this.usersDatabase[username];
            BlockedAccountValidator(account);

            if (account.IsBlocked)
            {
                throw new ArgumentException($"Account is blocked, try after {this.RemaningBlockTime} minutes!");
            }

            if (account.Password != password)
            {
                this.wrongPassCount--;
                if (this.wrongPassCount == 0)
                {
                    this.BlockAccount(account);
                    throw new ArgumentException($"{this.wrongPassCount} attemps left! Account is blocked for 15 minutes");
                }

                throw new ArgumentException($"Incorect password, try again! {this.wrongPassCount} attemps left!");
            }

            if (this.wrongPassCount == 0) this.wrongPassCount = WrongPassAttemps;

            account.LastLoggedInTime = DateTime.Now;
            this.currentLogedUser = this.usersDatabase[username];
            BlockedAccountValidator(account);
            return account;
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
                var autoSaveDatabase = new Thread(this.AutoSave);
                autoSaveDatabase.Start();
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
                // TODO: Do not save all data, only current logged player
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
