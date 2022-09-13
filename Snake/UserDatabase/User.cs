namespace UserDatabase
{
    using Interfaces;

    public class User : IUser
    {
        private string username;
        private string password;
        private int score;

        public User(string username, string password, int score)
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
                if (value.Length < 3)
                {
                    throw new ArgumentException("Username must be at least 3 characters long!");
                }
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username can not be empty!");
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

        public bool IsBlocked { get; set; } = false;

        public int BlockedTimeCount { get; set; }
    }
}
