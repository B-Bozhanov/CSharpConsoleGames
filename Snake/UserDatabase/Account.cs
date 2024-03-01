namespace UserDatabase
{
    using Interfaces;

    public class Account : IAccount
    {
        private string username;
        private string password;
        private int score;

        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Score = score;
        }


        public string Username
        {
            get => this.username;

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username can not be empty!");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("Username must be at least 3 characters long!");
                }
                this.username = value;
            }
        }

        public string Password
        {
            get => this.password;

            private set
            {
                if (!String.IsNullOrWhiteSpace(value) && value.Length < 4)
                {
                    throw new ArgumentException("Password must be at least 4 symbols long!");
                }
                this.password = value!;
            }
        }

        public int Score
        {
            get => this.score;
            set => this.score = value;
        }

        public int ExpiredBlockTime 
            => (int)(DateTime.Now - this.LastBlockedTime).TotalMinutes;

        public bool IsBlocked { get; set; } = false;

        public DateTime LastBlockedTime { get;  set; }

        public DateTime LastLoggedInTime { get; set; }

        public DateTime CreatedTime { get; set; }

    }
}
