namespace UserDatabase.Interfaces
{
    public interface IUser
    {
        public string Username { get;}

        public string Password { get;}

        public int Score { get; set; }

        public bool IsBlocked { get; set; }

        public DateTime LastBlockedTime { get; set; }

        public DateTime LastLoggedInTime { get; set; }

        public DateTime AccountCreatedTime { get; set; }
    }
}
